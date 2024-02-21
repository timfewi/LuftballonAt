using LuftballonAt.Domain.Repository.Contracts;
using LuftballonAt.Web.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // Implement Repositories here
        }

        public async Task SaveAsync()
        {
            var entities = _dbContext.ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseModel &&
                  (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                ((BaseModel)entity.Entity).LastModifiedDate = DateTime.UtcNow;
            }



            await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
            return _transaction;
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
