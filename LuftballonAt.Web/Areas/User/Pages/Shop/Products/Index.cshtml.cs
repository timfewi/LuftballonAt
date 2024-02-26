using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Implementations.ProductsService;
using LuftballonAt.Models.Dtos.CategoryDtos;
using LuftballonAt.Models.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuftballonAt.Web.Areas.User.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductColorService _productColorService;

        // Daten für die View als Properties
        public IEnumerable<ProductViewDto> Products { get; private set; }
        public IEnumerable<CategoryNamesDto> CategoryNames { get; private set; }

        // Formulardaten als Properties
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<long> CategoryIds { get; set; } = new List<long>();

        [BindProperty(SupportsGet = true)]
        public string SelectedColor { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? MaxPrice { get; set; }


        public IndexModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProductsAsync();
            CategoryNames = await _categoryService.GetAllCategoryNamesAsync();




            // Verwende die BindProperty-Werte hier, um die Produktsuche zu filtern
            Products = await _productService.GetFilteredProductsAsync(CategoryIds, SelectedColor, MinPrice, MaxPrice);

        }
    }

}
