using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Component
{
    public class EditModel : PageModel
    {
        private readonly IComponentRepository _context;

        public EditModel(IComponentRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public ComponentDTO Component { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var component = _context.GetComponentById(id ?? 0);
            if (component == null)
            {
                return NotFound();
            }
            Component = component;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var checkComponent = _context.GetComponentById(Component.ComponentId);
            if (checkComponent == null)
            {
                return NotFound();
            }

            var result = _context.UpdateComponent(Component);
            if (result)
            {
                TempData["comp-notification"] = "Update successfully";
            }
            else
            {
                TempData["comp-notification"] = "Update failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
