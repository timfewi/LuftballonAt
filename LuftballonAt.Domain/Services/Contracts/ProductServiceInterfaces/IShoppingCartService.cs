
using LuftballonAt.Models.Dtos.ShoppingCartDtos;
using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces
{
    public interface IShoppingCartService
    {

        Task<ShoppingCart> GetAllAsync(long? productId, long? appUserId);
        Task AddToCartAsync(long productId, long? appUserId, int quantity, string? token);
        Task UpdateCartItemQuantityAsync(long cartItemId, int newQuantity);
        Task RemoveFromCartAsync(long productId, long? userId, string? token);
        Task ClearUserCart(long? userId, string? token);
        Task<int> GetCartCount(long? userId, string? token);
        Task<double> GetCartTotal(long? userId, string? token);
        Task<IEnumerable<Product>> GetProductsFromShoppingList(long? userId, string? token);
    }
}

