using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ShoppingCartDtos
{

    public class ShoppingCartItemViewModel
    {
        public string ProductImageUrl { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public double PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }

}
