﻿using System;
namespace ExamKing.WebApp.Student
{
    /// <summary>
    /// 学生注册输出
    /// </summary>
    public class ResgisterOutput
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StuName { get; set; }

        /// <summary>
        /// 系别Id
        /// </summary>
        public int DeptId { get; set; }

        /// <summary>
        /// 班级Id
        /// </summary>
        public int ClassesId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string StuNo { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telphone { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCard { get; set; }
    }
}