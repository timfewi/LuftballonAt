using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ProductDtos;
using Microsoft.Extensions.Logging;
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
            var products = await _unitOfWork!.Product.GetAllAsync(includeProperties: "Category");
            var productDtos = _mapper!.Map<IEnumerable<ProductViewDto>>(products);
            return productDtos;
        }


        public async Task<ProductViewDto> GetProductByIdAsync(long id)
        {
            var product = await _unitOfWork!.Product.GetAsync(x => x.Id == id, includeProperties: "Category");
            var productDto = _mapper!.Map<ProductViewDto>(product);
            return productDto;
        }
    }
}
