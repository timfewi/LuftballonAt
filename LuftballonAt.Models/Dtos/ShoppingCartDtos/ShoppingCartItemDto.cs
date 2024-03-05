
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ShoppingCartDtos
{
    public class ShoppingCartItemDto
    {
        public long? ProductId { get; set; }
        public int Quantity { get; set; }
        public string? CartToken { get; set; }
        public long? AppUserId { get; set; }

    }
}
