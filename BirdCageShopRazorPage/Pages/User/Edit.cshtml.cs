using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _context;

        public EditModel(IUserRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public UserDTO User { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.GetUserById((int)id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _context.UpdateUserInformation(User);
            if (result)
            {
                TempData["user-notification"] = "Update information successfully";
            }
            else
            {
                TempData["user-notification"] = "Update information failed";
            }
            return RedirectToPage("./Details", new { id = User.UserId });
        }
    }
}