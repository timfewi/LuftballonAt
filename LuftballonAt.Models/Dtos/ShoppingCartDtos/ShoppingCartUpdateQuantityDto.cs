using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ShoppingCartDtos
{
    public class ShoppingCartUpdateQuantityDto
    {
        public long CartItemId { get; set; }
        public int NewQuantity { get; set; }
    }
}
