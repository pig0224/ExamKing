using System.Collections.Generic;
using System.Threading.Tasks;
using ExamKing.Application.Mappers;

namespace ExamKing.Application.Services
{
    /// <summary>
    /// 试卷服务接口
    /// </summary>
    public interface IExamService
    {
        /// <summary>
        /// 手动组卷
        /// </summary>
        /// <param name="examDto"></param>
        /// <returns></returns>
        public Task<ExamDto> CreateExam(ExamDto examDto);
        
        /// <summary>
        /// 自动组卷
        /// </summary>
        /// <param name="examDto"></param>
        /// <returns></returns>
        public Task<ExamDto> AutoCreateExam(ExamDto examDto);

        /// <summary>
        /// 更新试卷
        /// </summary>
        /// <param name="examDto"></param>
        /// <returns></returns>
        public Task<ExamDto> UpdateExam(ExamDto examDto);

        /// <summary>
        /// 删除试卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteExam(int id);

        /// <summary>
        /// 根据教师查询分页试卷
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<PagedList<ExamDto>> FindExamAllByTeacherAndPage(int teacherId, int pageIndex = 1, int pageSize = 10);

        /// <summary>
        /// 根据Id查询试卷
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ExamDto> FindExamById(int id);
        
    }
}