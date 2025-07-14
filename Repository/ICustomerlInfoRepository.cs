using WatchMate_API.Entities;

namespace WatchMate_API.Repository
{
    public interface ICustomerlInfoRepository : IGenericRepository<CustomerInfo>
    {
        Task<string> GenerateNextCustCardNoAsync();

    }
}
