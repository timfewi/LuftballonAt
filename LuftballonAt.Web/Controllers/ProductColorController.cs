using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Implementations.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuftballonAt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {
        private IProductColorService _productColorService;

        public ProductColorController(IProductColorService productColorService)
        {
            _productColorService = productColorService;
        }

        [HttpPost("extractColors")]
        public async Task<IActionResult> ExtractColorsForAllProducts()
        {
            await _productColorService.ExtractAndSaveColorsForAllProducts();
            return Ok();
        }

    }
}
