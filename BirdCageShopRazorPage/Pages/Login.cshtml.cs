using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BirdCageShopRazorPage.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public LoginUser LoginUser { get; set; } = default!;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.Login(LoginUser.Email, LoginUser.Password);
                if (user is null)
                {
                    TempData["warning"] = "Invalid email or password";
                    return Page();
                }

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName ?? "Undefined"),
                    new Claim(ClaimTypes.Email, user.Email ?? "Undefined"),
                    new Claim("scope", user.Role ?? "Undefined")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                HttpContext.SignInAsync(userPrincipal);

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }

    public class LoginUser
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
