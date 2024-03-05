using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ProductDtos
{
    public class SimilarProductsDto
    {
        public long? Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
    }
}
