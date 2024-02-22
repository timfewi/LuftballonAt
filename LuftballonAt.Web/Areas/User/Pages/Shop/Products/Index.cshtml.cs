using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Implementations.ProductsService;
using LuftballonAt.Models.Dtos.CategoryDtos;
using LuftballonAt.Models.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuftballonAt.Web.Areas.User.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public IEnumerable<ProductViewDto> Products { get; private set; }
        public IEnumerable<CategoryNamesDto> CategoryNames { get; private set; }

        public IndexModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProductsAsync();
            CategoryNames = await _categoryService.GetAllCategoryNamesAsync();
        }
    }

}
