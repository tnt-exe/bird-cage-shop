using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdCageShopRazorPage.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IAuthorizationService _authorizationService;

        public PrivacyModel(ILogger<PrivacyModel> logger, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var policyCheck = await _authorizationService.AuthorizeAsync(User, "Staff");

            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }

            return Page();
        }
    }
}