using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces
{
    public interface IProductColorService
    {
        Task ExtractAndSaveColorForProduct(long productId, string imageUrl);
        Task ExtractAndSaveColorsForAllProducts();
        Task ExtractAndSaveDominantColorForProduct(long productId, string imageUrl);
    }
}
