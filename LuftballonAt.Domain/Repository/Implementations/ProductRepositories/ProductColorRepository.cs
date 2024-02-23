using LuftballonAt.Data;
using LuftballonAt.Domain.Repository.Contracts.ProductRepoInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations.ProductRepositories
{
    public class ProductColorRepository : Repository<ProductColor>, IProductColorRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductColorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Product obj)
        {
            _db.Update(obj);
            await _db.SaveChangesAsync();
        }

    }
}
