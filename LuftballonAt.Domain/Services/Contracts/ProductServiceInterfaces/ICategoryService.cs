using LuftballonAt.Models.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryNamesDto>> GetAllCategoryNamesAsync();
    }
}
