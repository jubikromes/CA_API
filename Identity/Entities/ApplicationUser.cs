using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
