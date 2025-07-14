using WatchMate_API.DTO.UserRoles;
using WatchMate_API.Entities;

namespace WatchMate_API.Repository
{
    public interface IUserRoleRepository : IGenericRepository<UserRoles>
    {
        IEnumerable<UserRoles> GetUserRoleByIdCustom(int Id);
        Task<IEnumerable<DdlRolesDTO>> GetUserRolesAsync(bool IsGuestUser, string CompanyId);
        Task<IEnumerable<UserRolesInfoDTO>> GelAllUserRolesAsync(string companyId, bool IsAdministrator);
    }
}
