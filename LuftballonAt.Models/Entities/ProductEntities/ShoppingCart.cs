using LuftballonAt.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Entities.ProductEntities
{
    public class ShoppingCart : BaseModel
    {

        public long? AppUserId { get; set; }
        public long? ProductId { get; set; }

        public string? CartToken { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Die Menge muss größer als 0 sein.")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public virtual AppUser? AppUser { get; set; }
    }
}
