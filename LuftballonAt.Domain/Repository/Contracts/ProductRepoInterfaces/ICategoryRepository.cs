using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Contracts.ProductInterfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category obj);
    }
}
