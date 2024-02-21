using LuftballonAt.Domain.Repository.Contracts.ProductInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using LuftballonAt.Models.Entities.UtilityEntities;
using LuftballonAt.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations.ProductRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
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
