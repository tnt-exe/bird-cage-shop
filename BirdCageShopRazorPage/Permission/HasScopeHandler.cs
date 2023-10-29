using Microsoft.AspNetCore.Authorization;

namespace BirdCageShopRazorPage.Permission
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope"))
                return Task.CompletedTask;

            var scopes = context.User.Claims.Where(claim => claim.Type == "scope");

            if (scopes == null || scopes.Count() == 0)
                return Task.CompletedTask;

            foreach (var scope in scopes)
            {
                if (requirement.Scope.Contains(scope.Value))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
