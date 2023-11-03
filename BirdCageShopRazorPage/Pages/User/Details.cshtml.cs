using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.User
{
    public class DetailsModel : PageModel
    {
        private readonly IUserRepository _context;

        public DetailsModel(IUserRepository context)
        {
            _context = context;
        }

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
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
