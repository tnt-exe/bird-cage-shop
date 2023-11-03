using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _context;

        public IndexModel(ICategoryRepository context)
        {
            _context = context;
        }

        public IList<CategoryDTO> Category { get; set; } = default!;

        public void OnGet()
        {
            Category = _context.GetAllCategories();
        }

        public IActionResult OnGetChangeStatus(int? id)
        {
            var category = _context.GetCategoryById(id ?? 0);
            if (category == null || category.Status == (int)CategoryStatus.Inactive)
            {
                return NotFound();
            }

            var result = _context.DeleteCategory(category.CategoryId);

            return RedirectToPage();
        }
    }
}
