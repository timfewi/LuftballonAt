using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LuftballonAt.Web.Areas.Identity.Data;

namespace LuftballonAt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<AppUser> _userManager;

        public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<AppUser> userManager)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }


        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItemToCart([FromBody] ShoppingCartItemDto itemDto)
        {
            if (itemDto == null || itemDto.ProductId == null || itemDto.Quantity <= 0)
            {
                return BadRequest("Invalid item data.");
            }


            var cartToken = Request.Cookies["CartToken"];
            if (string.IsNullOrEmpty(itemDto.CartToken))
            {
                cartToken = GenerateCartToken();
                SetCartTokenCookie(cartToken);
            }
            else
            {
                cartToken = itemDto.CartToken;
            }

            var appUserId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : itemDto.AppUserId;

            await _shoppingCartService.AddToCartAsync(itemDto.ProductId.Value, appUserId, itemDto.Quantity, cartToken);
            return Ok(new { Message = "Item added successfully.", CartToken = cartToken });

        }


        [HttpPost("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] ShoppingCartItemDto itemDto)
        {
            if (itemDto.ProductId == null || itemDto.Quantity <= 0)
            {
                return BadRequest("Invalid request.");
            }

            var cartToken = Request.Cookies["CartToken"];
            var cartItemId = await _shoppingCartService.FindCartItemIdByProductIdAndCartToken(itemDto.ProductId.Value, cartToken!);

            if (cartItemId == null)
                return BadRequest("Item not found in cart.");


            await _shoppingCartService.UpdateCartItemQuantityAsync(cartItemId.Value, itemDto.Quantity, cartToken!);


            return Ok();
        }

        [HttpPost("RemoveItem")]
        public async Task<IActionResult> RemoveCartItem([FromBody] ShoppingCartItemDto itemDto)
        {
            if (itemDto.ProductId == null)
            {
                return BadRequest("Invalid request.");
            }


            var cartToken = Request.Cookies["CartToken"];
            var cartItemId = await _shoppingCartService.FindCartItemIdByProductIdAndCartToken(itemDto.ProductId.Value, cartToken!);

            if (cartItemId == null)
                return BadRequest("Item not found in cart.");


            await _shoppingCartService.RemoveFromCartAsync(cartItemId.Value, itemDto.Quantity, cartToken!);

            return Ok(new { Message = "Item removed successfully." });
        }

        [HttpPost("ClearCart")]
        public async Task<IActionResult> ClearCart()
        {
            string cartToken = Request.Cookies["CartToken"]!;
            long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;

            if (string.IsNullOrEmpty(cartToken) && !userId.HasValue)
            {
                return BadRequest("No cart token or user ID available to clear cart.");
            }

            await _shoppingCartService.ClearCartAsync(userId, cartToken);

            if (!userId.HasValue)
            {
                Response.Cookies.Delete("CartToken");
            }

            return Ok(new { Message = "Cart cleared successfully." });
        }

        [HttpGet("GetCartItemCount")]
        public async Task<IActionResult> GetCartItemCount()
        {
            string cartToken = Request.Cookies["CartToken"]!;
            long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;

            if (string.IsNullOrEmpty(cartToken) && !userId.HasValue)
            {
                return BadRequest("No cart token or user ID available to get item count.");
            }

            var count = await _shoppingCartService.GetCartCountAsync(userId, cartToken);

            return Ok(new { Count = count });
        }


        private string GenerateCartToken()
        {
            return Guid.NewGuid().ToString();
        }

        private void SetCartTokenCookie(string cartToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("CartToken", cartToken, cookieOptions);
        }


    }
}
