using WatchMate_API.DTO;
using WatchMate_API.Entities;

namespace WatchMate_API.Repository
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<IEnumerable<string>> GetUserRolePermissionById(int id);
        Task<IEnumerable<UsersDTO>> GetAllUsersAsync(string companyId, bool IsAdministrator);
        Task<IEnumerable<object>> GetDynamicMenue(int userId , int DataAccessLevel);
        Task<bool> CheckUserNameIsExist(string userName);  // Changed to accept userName
        Task<bool> CheckUserNameIsExistById(string userName, int userId);  // Changed to accept userName

        Task<IEnumerable<object>> GetUserIdAndNameAsync(string companyId, int? userId, int dataAccessLevel);

    }
}
