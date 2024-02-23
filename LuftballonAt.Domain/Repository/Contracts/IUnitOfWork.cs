using LuftballonAt.Domain.Repository.Contracts.ProductInterfaces;
using LuftballonAt.Domain.Repository.Contracts.ProductRepoInterfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Contracts
{
    public interface IUnitOfWork
    {

        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProductColorRepository ProductColor { get; }

        Task SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

    }
}
