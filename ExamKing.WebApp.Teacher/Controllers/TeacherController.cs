using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamKing.Application.Mappers;
using ExamKing.Application.Services;
using Mapster;
using Furion;
using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ExamKing.WebApp.Teacher
{
    /// <summary>
    /// 教师接口
    /// </summary>
    public class TeacherController : ApiControllerBase
    {
        private readonly ITeacherService _teacherService;
        /// <summary>
        /// 依赖注入
        /// </summary>
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// 教师登录
        /// </summary>
        /// <param name="teacherLoginInput"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<TeacherLoginOutput> PostLogin(TeacherLoginInput teacherLoginInput)
        {
            var teacher = await _teacherService.LoginTeacher(teacherLoginInput.TeacherNo, teacherLoginInput.Password);
            var output = teacher.Adapt<TeacherLoginOutput>();
            // 生成 token
            var jwtSettings = App.GetOptions<JWTSettingsOptions>();
            var datetimeOffset = new DateTimeOffset(DateTime.Now);
            if (jwtSettings.ExpiredTime != null)
                output.AccessToken = JWTEncryption.Encrypt(jwtSettings.IssuerSigningKey,
                    new Dictionary<string, object>()
                    {
                        {"UserId", teacher.Id}, // 存储Id
                        {JwtRegisteredClaimNames.Iat, datetimeOffset.ToUnixTimeSeconds()},
                        {JwtRegisteredClaimNames.Nbf, datetimeOffset.ToUnixTimeSeconds()},
                        {
                            JwtRegisteredClaimNames.Exp,
                            new DateTimeOffset(
                                    DateTime.Now.AddSeconds(
                                        jwtSettings.ExpiredTime.Value * 60 * 60 * 24 * 30))
                                .ToUnixTimeSeconds()
                        },
                        {JwtRegisteredClaimNames.Iss, jwtSettings.ValidIssuer},
                        {JwtRegisteredClaimNames.Aud, jwtSettings.ValidAudience}
                    });
            // 设置 Swagger 刷新自动授权
            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.Headers["access-token"] = output.AccessToken;

            return output;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> PostChangePass([FromForm] string password)
        {
            var teacherEntity = await GetTeacher();
            var teacher = new TeacherDto
            {
                Id = teacherEntity.Id,
                Password = password
            };

            await _teacherService.UpdateTeacher(teacher);
            return "success";
        }

        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <returns></returns>
        public async Task<TeacherOutput> GetInfo()
        {
            var teacherEntity = await GetTeacher();
            var teacher = await _teacherService.FindTeacherById(teacherEntity.Id);
            return teacher.Adapt<TeacherOutput>();
        }
    }
}