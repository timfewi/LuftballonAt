using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces
{
    public interface IProductColorService
    {
        Task ExtractAndSaveColorsForProduct(long productId, string imageUrl);
        Task ExtractAndSaveColorsForAllProducts();
    }
}
