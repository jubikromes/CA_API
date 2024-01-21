using OpenIddict.EntityFrameworkCore.Models;

namespace OpenIddictSetUp.Entities
{
    public class OpenIddict
    {
    }
    public class ConfamAppIddictApplication : OpenIddictEntityFrameworkCoreApplication<Guid, AppOpenIddictAuthorization, AppOpenIddictToken>
    {
        public ConfamAppIddictApplication()
        {
            Id = Guid.NewGuid();
        }
        public string? AppId { get; set; }
        public string? Language { get; set; }
    }

    public class AppOpenIddictAuthorization : OpenIddictEntityFrameworkCoreAuthorization<Guid, ConfamAppIddictApplication, AppOpenIddictToken> { }
    public class AppOpenIddictScope : OpenIddictEntityFrameworkCoreScope<Guid> { }
    public class AppOpenIddictToken : OpenIddictEntityFrameworkCoreToken<Guid, ConfamAppIddictApplication, AppOpenIddictAuthorization> { }


}