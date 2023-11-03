using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _context;

        public RegisterModel(IUserRepository context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserDTO User { get; set; } = default!;


        public IActionResult OnPost()
        {
            if (User.Email == null || User.Password == null)
            {
                ViewData["register-notification"] = "Email and password are required";
                return Page();
            }
            User.Role = "Customer";
            User.Status = (int)UserStatus.Active;

            var result = _context.Register(User);
            if (result)
            {
                TempData["register-notification"] = "Register successfully";
            }
            else
            {
                ViewData["register-notification"] = "Register failed!";
                return Page();
            }
            return RedirectToPage("./Login");
        }
    }
}