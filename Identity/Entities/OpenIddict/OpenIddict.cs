using OpenIddict.EntityFrameworkCore.Models;

namespace OpenIddictSetUp.Entities
{
    public class OpenIddict
    {
    }
    public class OpenIddictApplication : OpenIddictEntityFrameworkCoreApplication<Guid, OpenIddictAuthorization, OpenIddictToken>
    {
        public OpenIddictApplication()
        {
            Id = Guid.NewGuid();
        }
        public string? AppId { get; set; }
        public string? Language { get; set; }
    }

    public class OpenIddictAuthorization : OpenIddictEntityFrameworkCoreAuthorization<Guid, OpenIddictApplication, OpenIddictToken> { }
    public class OpenIddictScope : OpenIddictEntityFrameworkCoreScope<Guid> { }
    public class OpenIddictToken : OpenIddictEntityFrameworkCoreToken<Guid, OpenIddictApplication, OpenIddictAuthorization> { }


}