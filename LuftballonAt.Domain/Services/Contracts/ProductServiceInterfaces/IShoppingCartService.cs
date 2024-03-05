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
        Task<IEnumerable<ShoppingCart>> GetAllForUserAsync(long? appUserId);
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartItemsForTokenUserAsync(string cartToken);
        Task AddToCartAsync(long productId, long? appUserId, int quantity, string? cartToken);
        Task UpdateCartItemQuantityAsync(long cartItemId, int newQuantity, string cartToken);
        Task RemoveFromCartAsync(long cartItemId, int amount, string cartToken);
        Task ClearCartAsync(long? appUserId, string? cartToken);
        Task<int> GetCartCountAsync(long? appUserId, string? cartToken);
        Task<double> GetCartTotalAsync(long? appUserId, string? cartToken);
    }
}
