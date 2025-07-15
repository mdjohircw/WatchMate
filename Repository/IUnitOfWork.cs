﻿using Microsoft.EntityFrameworkCore.Storage;

namespace WatchMate_API.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IUserRoleRepository UserRole { get; }
        ILoginRepository Login { get; }
        IPackageRepository Package { get; }
        ICustomerPackageRepository UserPackages { get; }
        ICustomerlInfoRepository CustomerInfo { get; }
        IVideoRepository Video { get; }
        ITransctionRepository Transaction { get; }



        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> Save();
    }
}
