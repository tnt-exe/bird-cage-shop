using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Component
{
    public class CreateModel : PageModel
    {
        private readonly IComponentRepository _context;

        public CreateModel(IComponentRepository context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ComponentDTO Component { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _context.AddComponent(Component);
            if (result)
            {
                TempData["comp-notification"] = "Add new successfully";
            }
            else
            {
                TempData["comp-notification"] = "Add new failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
