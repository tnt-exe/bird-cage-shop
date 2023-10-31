using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    public class DeleteModel : PageModel
    {
        private readonly ICageRepository _cageRepository;

        public DeleteModel(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        [BindProperty]
        public CageDTO Cage { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            var cage = _cageRepository.GetCageById(id ?? 0);

            if (cage == null)
            {
                return NotFound();
            }
            else
            {
                Cage = cage;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            var result = _cageRepository.RemoveCage(id ?? 0);

            if (result)
            {
                TempData["notification"] = "Delete successfully";
            }
            else
            {
                TempData["notification"] = "Delete failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
