using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuftballonAt.Web.Areas.Admin.Pages.Panel.Products
{
    public class CreateNewProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public CreateProductViewDto Product { get; set; }


        public CreateNewProductModel(IProductService productService, IProductColorService productColorService, ICategoryService categoryService)
        {
            _productService = productService;
            _productColorService = productColorService;
            _categoryService = categoryService;
            Product = new CreateProductViewDto();
        }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var createdProductId = await _productService.CreateProductAsync(Product);

                if (!string.IsNullOrWhiteSpace(Product.ImageUrl))
                {
                    await _productColorService.ExtractAndSaveColorForProduct(createdProductId, Product.ImageUrl);


                }

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ein Fehler ist aufgetreten beim Erstellen des Produkts., {ex.Message}");
                return Page();
            }



        }
    }
}
