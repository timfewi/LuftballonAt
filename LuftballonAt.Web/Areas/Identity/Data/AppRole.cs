using Microsoft.AspNetCore.Identity;

namespace LuftballonAt.Web.Areas.Identity.Data
{
    public class AppRole : IdentityRole<long>
    {
        public string Description { get; set; } = string.Empty;
    }
}
