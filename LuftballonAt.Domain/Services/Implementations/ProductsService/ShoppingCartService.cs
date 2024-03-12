using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;
using LuftballonAt.Models.Entities.ProductEntities;
using LuftballonAt.Web.Areas.Identity.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations.ProductsService
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        public ShoppingCartService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllForUserAsync(long? appUserId)
        {
            var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(
                filter: sc => sc.AppUserId == appUserId,
                includeProperties: "Product");
            return cartItems;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartItemsForTokenUserAsync(string cartToken)
        {
            var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(
                filter: sc => sc.CartToken == cartToken,
                includeProperties: "Product");
            return cartItems;
        }


        public async Task AddToCartAsync(long productId, long? appUserId, int quantity, string? cartToken)
        {
            ShoppingCart? existingCartItem = null;
            if (appUserId.HasValue)
            {
                existingCartItem = await _unitOfWork.ShoppingCart.GetAsync(x => x.ProductId == productId && x.AppUserId == appUserId.Value);
            }
            else if (!string.IsNullOrEmpty(cartToken))
            {
                existingCartItem = await _unitOfWork.ShoppingCart.GetAsync(x => x.ProductId == productId && x.CartToken == cartToken);
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
                    CartToken = cartToken,
                    Quantity = quantity
                };
                await _unitOfWork.ShoppingCart.AddAsync(cartItem);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCartItemQuantityAsync(long cartItemId, int newQuantity, string? cartToken)
        {
            ShoppingCart cartItem;
            if (!string.IsNullOrEmpty(cartToken))
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.Id == cartItemId && ci.CartToken == cartToken);
            }
            else
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.Id == cartItemId);
            }

            if (cartItem == null)
            {
                throw new KeyNotFoundException("Warenkorbartikel nicht gefunden.");
            }

            cartItem.Quantity = newQuantity;
            await _unitOfWork.ShoppingCart.UpdateAsync(cartItem);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveFromCartAsync(long cartItemId, int amount, string? cartToken)
        {
            ShoppingCart cartItem;
            if (!string.IsNullOrEmpty(cartToken))
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.Id == cartItemId && ci.CartToken == cartToken);
            }
            else
            {
                cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.Id == cartItemId);
            }

            if (cartItem == null)
            {
                throw new KeyNotFoundException("Warenkorbartikel nicht gefunden.");
            }

            cartItem.Quantity -= amount;
            if (cartItem.Quantity <= 0)
            {
                _unitOfWork.ShoppingCart.Remove(cartItem);
            }
            else
            {
                await _unitOfWork.ShoppingCart.UpdateAsync(cartItem);
            }
            await _unitOfWork.SaveAsync();
        }



        public async Task ClearCartAsync(long? appUserId, string? cartToken)
        {
            if (appUserId.HasValue)
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(filter: sc => sc.AppUserId == appUserId);
                _unitOfWork.ShoppingCart.RemoveRange(cartItems);

            }
            else if (!string.IsNullOrEmpty(cartToken))
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(filter: sc => sc.CartToken == cartToken);
                _unitOfWork.ShoppingCart.RemoveRange(cartItems);
            }
            await _unitOfWork.SaveAsync();
        }


        public async Task<int> GetCartCountAsync(long? appUserId, string? cartToken)
        {
            if (appUserId.HasValue)
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.AppUserId == appUserId.Value);
                return cartItems.Sum(ci => ci.Quantity);
            }
            else if (!string.IsNullOrEmpty(cartToken))
            {
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(ci => ci.CartToken == cartToken);
                return cartItems.Sum(ci => ci.Quantity);
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um die Warenkorb-Menge zu erhalten.");
            }
        }


        // Diese Methode bleibt unverändert, da sie spezifisch für angemeldete Benutzer ist
        public async Task<double> GetCartTotalAsync(long? appUserId, string? cartToken)
        {
            if (appUserId.HasValue)
            {
                var cartItems = await GetAllForUserAsync(appUserId);
                return cartItems.Sum(item => item.Quantity * item.Product!.Price);
            }
            else if (!string.IsNullOrEmpty(cartToken))
            {
                var cartItems = await GetAllShoppingCartItemsForTokenUserAsync(cartToken);
                return cartItems.Sum(item => item.Quantity * item.Product!.Price);
            }
            else
            {
                throw new ArgumentException("Ein Benutzer-ID oder Token ist erforderlich, um den Warenkorb-Menge zu erhalten.");
            }
        }

        public async Task<long?> FindCartItemIdByProductIdAndCartToken(long productId, string cartToken)
        {
            var cartItem = await _unitOfWork.ShoppingCart.GetAsync(ci => ci.ProductId == productId && ci.CartToken == cartToken);
            return cartItem?.Id;
        }
    }
}
