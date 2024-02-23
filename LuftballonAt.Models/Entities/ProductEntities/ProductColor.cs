using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Entities.ProductEntities
{
    public class ProductColor : BaseModel
    {

        public string? ColorHex { get; set; }



        // Navigation Properties
        public long ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
