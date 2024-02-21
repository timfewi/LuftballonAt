
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LuftballonAt.Web.Areas.Identity.Data
{
    public class AppUser : IdentityUser<long>
    {

        [PersonalData]
        public string? FirstName { get; set; }
        [PersonalData]
        public string? LastName { get; set; }
        [PersonalData]
        public DateTime DateOfBirth { get; set; }
    }
}
