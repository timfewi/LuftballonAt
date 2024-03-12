using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LuftballonAt.Web.Areas.User.Pages.Shop.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;

        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; } = new List<ShoppingCartItemViewModel>();

        public SummaryModel(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task OnGetAsync()
        {
            var userId = User.Identity!.IsAuthenticated ? long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!) : 0;
            var cartToken = Request.Cookies["CartToken"];
            IEnumerable<ShoppingCart> cartItems;
            if (userId > 0)
            {
                cartItems = await _shoppingCartService.GetAllForUserAsync(userId);
            }
            else if (!string.IsNullOrEmpty(cartToken))
            {
                cartItems = await _shoppingCartService.GetAllShoppingCartItemsForTokenUserAsync(cartToken);
            }
            else
            {
                cartItems = new List<ShoppingCart>();
            }

            ShoppingCartItems = cartItems.Select(item => new ShoppingCartItemViewModel
            {
                Id = item.Product!.Id,
                ProductImageUrl = item.Product!.ImageUrl!,
                ProductName = item.Product.Name!,
                PricePerUnit = item.Product.Price,
                Quantity = item.Quantity,
                TotalPrice = item.Quantity * item.Product.Price
            }).ToList();
        }

    }
}
