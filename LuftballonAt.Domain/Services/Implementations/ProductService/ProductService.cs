using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.ProductService
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IEnumerable<ProductViewDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork!.Product.GetAllAsync();
            var productDtos = _mapper!.Map<IEnumerable<ProductViewDto>>(products);
            return productDtos;
        }
    }
}
