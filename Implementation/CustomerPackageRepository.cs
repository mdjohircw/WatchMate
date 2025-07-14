using WatchMate_API.Entities;
using WatchMate_API.Migrations;
using WatchMate_API.Repository;

namespace WatchMate_API.Implementation
{
    public class CustomerPackageRepository : GenericRepository<CustomerPackage>, ICustomerPackageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private static List<PermissionRouteDTO> PermissionList = new List<PermissionRouteDTO>();
        //public List<PermissionRouteDTO> PermissionList { get; set; }
        public CustomerPackageRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
