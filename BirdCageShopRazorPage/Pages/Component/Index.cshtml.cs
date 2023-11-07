using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Component
{
    public class IndexModel : PageModel
    {
        private readonly IComponentRepository _context;

        public IndexModel(IComponentRepository context)
        {
            _context = context;
        }

        public IList<ComponentDTO> Component { get; set; } = default!;

        public void OnGet()
        {
            Component = _context.GetAllComponent();
        }

        public IActionResult OnGetDeleteComponent(int? id)
        {
            var component = _context.GetComponentById(id ?? 0);
            if (component == null)
            {
                return NotFound();
            }

            var result = _context.DeleteComponent(component.ComponentId);
            if (result)
            {
                TempData["comp-notification"] = "Delete component successfully!";
            }
            else
            {
                TempData["comp-notification"] = "Delete component failed!";
            }
            return RedirectToPage();
        }
    }
}
