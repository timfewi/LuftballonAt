using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.ProductsService
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<IEnumerable<CategoryNamesDto>> GetAllCategoryNamesAsync()
        {
            var categories = _unitOfWork!.Category.GetAll();
            var categoryDtos = _mapper!.Map<IEnumerable<CategoryNamesDto>>(categories);
            return Task.FromResult(categoryDtos);
        }
    }
}
