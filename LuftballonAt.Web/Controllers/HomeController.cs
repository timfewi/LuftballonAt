using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Domain.Services.Implementations.ProductService;
using LuftballonAt.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LuftballonAt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
