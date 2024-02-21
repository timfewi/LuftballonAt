using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Services.Implementations
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

    }
}
