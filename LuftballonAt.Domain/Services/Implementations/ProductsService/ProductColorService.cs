using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.ProductsService
{
    public class ProductColorService : BaseService, IProductColorService
    {
        private readonly IColorAnalysisService _colorAnalysisService;
        private readonly IProductService _productService;
        public ProductColorService(
            IServiceProvider serviceProvider,
            IColorAnalysisService colorAnalysisService,
            IProductService productService
            ) : base(serviceProvider)
        {
            _colorAnalysisService = colorAnalysisService;
            _productService = productService;
        }

        public async Task ExtractAndSaveColorsForProduct(long productId, string imageUrl)
        {
            var colors = await _colorAnalysisService.ExtractDominantColors(imageUrl);

            foreach (var color in colors)
            {
                var productColor = new ProductColor
                {
                    ProductId = productId,
                    ColorHex = color.ToHexString(),
                };

                await _unitOfWork!.ProductColor.AddAsync(productColor);
            }
            await _unitOfWork!.SaveAsync();
        }

        public async Task ExtractAndSaveColorsForAllProducts()
        {
            var products = await _productService.GetAllEntityProductsAsync();

            foreach (var product in products)
            {
                if (product.Colors.Any())
                    continue;

                await ExtractAndSaveColorsForProduct(product.Id, product.ImageUrl!);
            }
        }


    }
}
