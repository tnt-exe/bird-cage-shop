using DataTransferObject;
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
    }
}
