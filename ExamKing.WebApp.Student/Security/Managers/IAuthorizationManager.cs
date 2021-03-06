using System.Threading.Tasks;
using ExamKing.Application.Mappers;

namespace ExamKing.WebApp.Student
{
    /// <summary>
    /// 权限管理器
    /// </summary>
    public interface IAuthorizationManager
    {
        /// <summary>
        /// 获取学生实体
        /// </summary>
        /// <returns></returns>
        Task<StudentDto> GetStudent();

        /// <summary>
        /// 检查授权
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        bool CheckSecurity(string resourceId);
    }
}