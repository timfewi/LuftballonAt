using LuftballonAt.Domain.Repository.Contracts.ProductInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using LuftballonAt.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations.ProductRepositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        protected readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Category obj)
        {
            _db.Categories.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
