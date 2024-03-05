using LuftballonAt.Data;
using LuftballonAt.Domain.Repository.Contracts.ProductRepoInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Implementations.ProductRepositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ShoppingCart obj)
        {
            _db.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
