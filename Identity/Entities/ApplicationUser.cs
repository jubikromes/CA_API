using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string CountryCode {  get; set; }
        public string PhoneCode { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
