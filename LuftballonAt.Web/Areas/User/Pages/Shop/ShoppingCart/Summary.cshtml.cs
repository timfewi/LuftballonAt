using LuftballonAt.Domain.Services.Contracts.ProductServiceInterfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LuftballonAt.Web.Areas.User.Pages.Shop.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;



        public SummaryModel(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public async Task OnGetAsync(string cartToken)
        {

        }
    }
}
