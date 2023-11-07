using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _context;

        public IndexModel(IUserRepository context)
        {
            _context = context;
        }

        public IList<UserDTO> User { get; set; } = default!;

        public IActionResult OnGet()
        {
            User = _context.GetAllUsers()
                .Where(user => user.Role == "Customer")
                .ToList();
            return Page();
        }

        public IActionResult OnGetChangeStatus(int? userId, int? currentStatus)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var newStatus = (int)((currentStatus == (int)UserStatus.Active) ?
                UserStatus.Ban : UserStatus.Active);
            _context.ChangeUserStatus((int)userId, newStatus);
            return RedirectToPage();
        }
    }
}
