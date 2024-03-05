using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using LuftballonAt.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddItemToCart([FromBody] ShoppingCartItemAddDto itemDto)
        {
            var userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : (long?)null;
            var token = !User.Identity.IsAuthenticated ? itemDto.CartToken : null;

            if (itemDto.ProductId == 0 || itemDto.Quantity <= 0)
            {
                return BadRequest("Invalid product ID or quantity.");
            }

            await _shoppingCartService.AddToCartAsync(itemDto.ProductId, userId, itemDto.Quantity, token);

            return Ok();
        }

        [HttpPost("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] ShoppingCartUpdateQuantityDto updateDto)
        {
            try
            {
                await _shoppingCartService.UpdateCartItemQuantityAsync(updateDto.CartItemId, updateDto.NewQuantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RemoveItem")]
        public async Task<IActionResult> RemoveCartItem([FromBody] ShoppingCartRemoveItemDto dto)
        {
            try
            {
                long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;
                await _shoppingCartService.RemoveFromCartAsync(dto.ProductId, userId, dto.CartToken);
                return Ok(new { Message = "Item removed successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("ClearCart")]
        public async Task<IActionResult> ClearCart([FromBody] string cartToken)
        {
            try
            {
                var userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : (long?)null;
                await _shoppingCartService.ClearUserCart(userId, cartToken);
                return Ok(new { Message = "Cart cleared successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("GetCartItemCount")]
        public async Task<IActionResult> GetCartItemCount([FromQuery] string cartToken)
        {
            long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;
            var count = await _shoppingCartService.GetCartCount(userId, cartToken);
            return Ok(new { Count = count });
        }


        [HttpGet("GetCartTotal")]
        public async Task<IActionResult> GetCartTotal([FromQuery] string cartToken)
        {
            long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;
            var total = await _shoppingCartService.GetCartTotal(userId, cartToken);
            return Ok(new { Total = total });
        }

        [HttpGet("GetProductsFromShoppingList")]
        public async Task<IActionResult> GetProductsFromShoppingList([FromQuery] string cartToken)
        {
            long? userId = User.Identity!.IsAuthenticated ? long.Parse(_userManager.GetUserId(User)!) : null;
            var products = await _shoppingCartService.GetProductsFromShoppingList(userId, cartToken);
            return Ok(products);
        }



    }
}
