using LuftballonAt.Models.Dtos.ProductDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewDto>> GetAllProductsAsync();
        Task<ProductViewDto> GetProductByIdAsync(long id);
        Task<IEnumerable<Product>> GetAllEntityProductsAsync();
        Task<long> CreateProductAsync(CreateProductViewDto createProductViewDto);
    }
}
