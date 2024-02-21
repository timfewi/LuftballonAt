using LuftballonAt.Models.Entities.UtilityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Entities.ProductEntities
{
    [Table(nameof(Category))]
    public class Category : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
