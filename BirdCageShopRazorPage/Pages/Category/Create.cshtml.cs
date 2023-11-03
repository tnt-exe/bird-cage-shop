using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _context;

        public CreateModel(ICategoryRepository context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CategoryDTO Category { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _context.AddCategory(Category);
            if (result)
            {
                TempData["cate-notification"] = "Add new successfully";
            }
            else
            {
                TempData["cate-notification"] = "Add new failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
