using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ICategoryRepository _context;

        public EditModel(ICategoryRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryDTO Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var category = _context.GetCategoryById(id ?? 0);
            if (category == null)
            {
                return NotFound();
            }

            Category = category;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var checkCategory = _context.GetCategoryById(Category.CategoryId);
            if (checkCategory == null)
            {
                return NotFound();
            }

            var result = _context.UpdateCategory(Category);
            if (result)
            {
                TempData["cate-notification"] = "Update successfully";
            }
            else
            {
                TempData["cate-notification"] = "Update failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
