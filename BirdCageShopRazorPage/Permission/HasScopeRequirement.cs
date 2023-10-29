using Microsoft.AspNetCore.Authorization;

namespace BirdCageShopRazorPage.Permission
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Scope { get; set; } = "";

        public HasScopeRequirement(string scope)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}
