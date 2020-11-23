﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamKing.Application.Services;
using Mapster;

namespace ExamKing.WebApp.Student
{
    /// <summary>
    /// 考试接口
    /// </summary>
    public class ExamController : ApiControllerBase
    {
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="examService"></param>
        /// <param name="studentService"></param>
        public ExamController(
            IExamService examService,
            IStudentService studentService)
        {
            _examService = examService;
            _studentService = studentService;
        }

        /// <summary>
        /// 查询正在考试列表
        /// </summary>
        /// <returns></returns>
        public async Task<PagedList<ExamOutput>> GetExamOnLineList()
        {
            var student = await GetStudent();
            var exams = await _examService.FindExamOnlineByClassesAndPage(student.ClassesId);
            return exams.Adapt<PagedList<ExamOutput>>();
        }
    }
}