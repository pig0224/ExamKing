﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ExamKing.Application.Services;
using ExamKing.Application.Mappers;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace ExamKing.WebApp.Student
{
    /// <summary>
    /// 系别接口
    /// </summary>
    public class DeptController : ApiControllerBase
    {
        private readonly IDeptService _deptService;

        /// <inheritdoc />
        public DeptController(IDeptService deptService)
        {
            _deptService = deptService;
        }

        /// <summary>
        /// 查询全部系别
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<List<DeptClassesOutput>> GetDeptAll()
        {
            var depts = await _deptService.FindDeptAll();
            return depts.Adapt<List<DeptClassesOutput>>();
        }
    }
}
