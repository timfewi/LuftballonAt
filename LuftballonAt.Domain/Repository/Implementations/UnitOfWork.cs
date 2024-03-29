﻿using LuftballonAt.Domain.Repository.Contracts;
using LuftballonAt.Domain.Repository.Contracts.ProductInterfaces;
using LuftballonAt.Domain.Repository.Implementations.ProductRepositories;
using LuftballonAt.Models;
using LuftballonAt.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuftballonAt.Domain.Repository.Contracts.ProductRepoInterfaces;
using LuftballonAt.Domain.Repository.Contracts.AppUserRepositories;
using LuftballonAt.Domain.Repository.Implementations.AppUserRepositories;

namespace LuftballonAt.Domain.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transaction;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductColorRepository ProductColor { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IAppUserRepository AppUser { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            ProductColor = new ProductColorRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            AppUser = new AppUserRepository(_db);
        }

        public async Task SaveAsync()
        {
            var entities = _db.ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseModel &&
                  (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                ((BaseModel)entity.Entity).LastModifiedDate = DateTime.UtcNow;
            }



            await _db.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
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
