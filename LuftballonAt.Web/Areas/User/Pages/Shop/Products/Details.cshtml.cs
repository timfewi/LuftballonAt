using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuftballonAt.Web.Areas.User.Pages.Shop.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductViewDto Product { get; private set; }
        public IEnumerable<SimilarProductsDto>? SimilarProducts { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Amount { get; set; }

        [BindProperty(SupportsGet = true)]
        public double TotalPrice { get; set; }

        public DetailsModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        public async Task OnGetAsync(long id)
        {
            Product = await _productService.GetProductByIdAsync(id);
            SimilarProducts = await _productService.GetSimilarProductsByCategoryAsync(id);
        }
    }
}
