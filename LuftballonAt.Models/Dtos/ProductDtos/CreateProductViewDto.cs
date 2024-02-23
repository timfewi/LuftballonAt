using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ProductDtos
{
    public class CreateProductViewDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        //public IFormFile? Image { get; set; }  = null!;  Vorerst nicht benötigt weil kein BildUpload host vorhanden.
        public double Price { get; set; }
        public int Stock { get; set; }
        public long CategoryId { get; set; } = 1;
    }
}
