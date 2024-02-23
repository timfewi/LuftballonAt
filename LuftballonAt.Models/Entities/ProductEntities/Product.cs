using LuftballonAt.Models.Entities.UtilityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Entities.ProductEntities
{
    [Table(nameof(Product))]
    public class Product : BaseModel
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ArticleNumber { get; set; } // Automatische generierung von InStock , Namens Konvention für Artikelnummer muss erstellt werden
        public int Stock { get; set; }
        public bool InStock { get; set; } // Automatische generierung von InStock
        public string? ImageUrl { get; set; } = string.Empty;

        // Navigation properties

        [ForeignKey(nameof(CategoryId))]
        public long CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<ProductColor> Colors { get; set; } = new List<ProductColor>();
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
