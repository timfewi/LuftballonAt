using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.ProductsService
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        public ShoppingCartService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<ShoppingCart> GetAllAsync(long? productId, long? appUserId)
        {
            try
            {
                if (productId == null || appUserId == null)
                    return null!;

                var existingCartItem = await _unitOfWork.ShoppingCart.GetAsync(x => x.ProductId == productId && x.AppUserId == appUserId);
                return existingCartItem!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ShoppingCartService.GetAllAsync");
                throw;
            }
        }

        public async Task AddToCartAsync(long productId, long? appUserId, int quantity, string? token)
        {
            ShoppingCart? existingCartItem = null;
            if (appUserId.HasValue)
            {
                existingCartItem = await _unitOfWork.ShoppingCart.GetAsync(x => x.ProductId == productId && x.AppUserId == appUserId.Value);
            }
            else if (!string.IsNullOrEmpty(token))
            {
                existingCartItem = await _unitOfWork.ShoppingCart.GetAsync(x => x.ProductId == productId && x.CartToken == token);
            }

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                await _unitOfWork.ShoppingCart.UpdateAsync(existingCartItem);
            }
            else
            {
                var cartItem = new ShoppingCart
                {
                    ProductId = productId,
                    AppUserId = appUserId,
                    CartToken = token,
                    Quantity = quantity
                };
                await _unitOfWork.ShoppingCart.AddAsync(cartItem);
            }
            await _unitOfWork.SaveAsync();
        }


        public async Task UpdateCartItemQuantityAsync(long cartItemId, int newQuantity)
        {
            var cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.Id == cartItemId);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("Warenkorbartikel nicht gefunden.");
            }

            cartItem.Quantity = newQuantity;
            await _unitOfWork.ShoppingCart.UpdateAsync(cartItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveFromCartAsync(long productId, long? userId, string? token)
        {
            ShoppingCart? cartItem;
            if (userId.HasValue)
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.ProductId == productId && ci.AppUserId == userId.Value);
            }
            else
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.ProductId == productId && ci.CartToken == token);
            }

            if (cartItem != null)
            {
                _unitOfWork.ShoppingCart.Remove(cartItem);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new KeyNotFoundException("Warenkorbartikel nicht gefunden.");
            }
        }

        public async Task ClearUserCart(long? userId, string? token)
        {
            if (userId.HasValue)
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.AppUserId == userId.Value);
                _unitOfWork.ShoppingCart.RemoveRange(cartItems);
            }
            else if (!string.IsNullOrEmpty(token))
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.CartToken == token);
                _unitOfWork.ShoppingCart.RemoveRange(cartItems);
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um den Warenkorb zu löschen.");
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<int> GetCartCount(long? userId, string? token)
        {
            if (userId.HasValue)
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.AppUserId == userId.Value);
                return cartItems.Sum(ci => ci.Quantity);
            }
            else if (!string.IsNullOrEmpty(token))
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.CartToken == token);
                return cartItems.Sum(ci => ci.Quantity);
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um die Warenkorb-Menge zu erhalten.");
            }
        }

        public async Task<double> GetCartTotal(long? userId, string? token)
        {
            IEnumerable<ShoppingCart> cartItems;
            if (userId.HasValue)
            {
                cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.AppUserId == userId.Value, includeProperties: "Product");
            }
            else if (!string.IsNullOrEmpty(token))
            {
                cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.CartToken == token, includeProperties: "Product");
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um den Gesamtbetrag des Warenkorbs zu erhalten.");
            }

            return cartItems.Sum(ci => ci.Quantity * ci.Product!.Price);
        }

        public async Task<IEnumerable<Product>> GetProductsFromShoppingList(long? userId, string? token)
        {
            if (userId.HasValue)
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.AppUserId == userId.Value, includeProperties: "Product");
                return cartItems.Select(ci => ci.Product!);
            }
            else if (!string.IsNullOrEmpty(token))
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.CartToken == token, includeProperties: "Product");
                return cartItems.Select(ci => ci.Product!);
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um die Produkte aus der Einkaufsliste zu erhalten.");
            }
        }
    }
}
