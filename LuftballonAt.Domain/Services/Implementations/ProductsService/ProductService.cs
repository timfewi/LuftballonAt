using ImageMagick;
using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Contracts.UtilityServiceInterfaces;
using LuftballonAt.Models.Dtos.ProductDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using Microsoft.EntityFrameworkCore;
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
        private readonly IColorAnalysisService _colorAnalysisService;
        public ProductService(IServiceProvider serviceProvider, IColorAnalysisService colorAnalysisService) : base(serviceProvider)
        {
            _colorAnalysisService = colorAnalysisService;
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

        public async Task<IEnumerable<Product>> GetAllEntityProductsAsync()
        {
            var products = await _unitOfWork!.Product.GetAllAsync();
            return products;
        }

        public async Task<long> CreateProductAsync(CreateProductViewDto createProductViewDto)
        {
            var product = _mapper!.Map<Product>(createProductViewDto);
            await _unitOfWork!.Product.AddAsync(product);
            await _unitOfWork!.SaveAsync();

            return product.Id;
        }

        public async Task<IEnumerable<ProductViewDto>> GetFilteredProductsAsync(List<long> categoryIds, string? selectedColorHex, double? minPrice, double? maxPrice)
        {
            // Verwende das Product-Repository aus dem UnitOfWork
            var query = _unitOfWork.Product.GetAll(includeProperties: "Category,Colors");

            // Filtere nach Kategorie-IDs
            if (categoryIds.Any())
            {
                query = query.Where(p => categoryIds.Contains(p.CategoryId));
            }

            double threshold = 150; // Schwellenwert für die Farbähnlichkeit

            // Filtere nach ähnlicher Farbe
            if (!string.IsNullOrWhiteSpace(selectedColorHex))
            {
                // Hole die IDs der Produkte, die ähnliche Farben haben
                var similarProductIds = await _colorAnalysisService.FindSimilarColors(selectedColorHex, threshold);
                // Filtere die Produkte basierend auf diesen IDs
                query = query.Where(p => p.Colors.Any(c => similarProductIds.Contains(p.Id)));
            }

            // Filtere nach Preis
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            // Projektion auf ProductViewDto
            var products = query.Select(p => new ProductViewDto
            {
                Id = p.Id,
                Name = p.Name!,
                Description = p.Description!,
                Price = p.Price,
                ArticleNumber = p.ArticleNumber!,
                InStock = p.InStock,
                ImageUrl = p.ImageUrl!,
                CategoryName = p.Category?.Name ?? string.Empty
            }).ToList();

            return products;
        }



        public Task<IEnumerable<ProductViewDto>> GetSearchedProductsAsync(string? search)
        {
            throw new NotImplementedException();
        }
    }
}
