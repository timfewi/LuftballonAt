using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Models.Dtos.ShoppingCartDtos
{
    public class ShoppingCartRemoveItemDto
    {
        public long ProductId { get; set; }
        public string? CartToken { get; set; }
    }

}
