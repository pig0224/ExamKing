﻿using System;
using System.Collections.Generic;

namespace ExamKing.Application.Mappers
{
    
    /// <summary>
    /// 系别DTO
    /// </summary>
    public class DeptDto
    {

        /// <summary>
        /// 系别Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 系别名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        
        /// <summary>
        /// 关联班级
        /// </summary>
        public List<DeptClassesDto> Classes { get; set; }
        
    }
    
    /// <summary>
    /// 系别关联班级 DTO
    /// </summary>
    public class DeptClassesDto
    {

        /// <summary>
        /// 班级Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassesName { get; set; }

        ///// <summary>
        ///// 系别Id
        ///// </summary>
        public int DeptId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

    }

}
