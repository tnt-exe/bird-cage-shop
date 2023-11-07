using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    public class DetailsModel : PageModel
    {
        private readonly ICageRepository _cageRepository;
        private readonly ICageComponentRepository _cageComponentRepository;

        public DetailsModel(ICageRepository cageRepository, ICageComponentRepository cageComponentRepository)
        {
            _cageRepository = cageRepository;
            _cageComponentRepository = cageComponentRepository;
        }

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

        public IActionResult OnGetDeleteCageComponent(int cageComponentId, int cageId)
        {
            var isRequired = _cageComponentRepository.IsCageComponentRequired(cageComponentId);
            if (isRequired)
            {
                TempData["cage-notification"] = "This component is required";
            }
            else
            {
                var result = _cageComponentRepository.DeleteCageComponent(cageComponentId);
                if (result)
                {
                    TempData["cage-notification"] = "Delete successfully";
                }
                else
                {
                    TempData["cage-notification"] = "Delete failed";
                }
            }
            return RedirectToPage("./Details", new { id = cageId });
        }
    }
}
