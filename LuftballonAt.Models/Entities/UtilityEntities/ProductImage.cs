using LuftballonAt.Models.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Entities.UtilityEntities
{
    [Table(nameof(ProductImage))]
    public class ProductImage : BaseModel
    {
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }


        // Navigation properties

        [ForeignKey(nameof(ProductId))]
        public long? ProductId { get; set; }
        public virtual Product? Product { get; set; }



    }
}
