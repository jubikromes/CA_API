using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name)
        {
        }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
