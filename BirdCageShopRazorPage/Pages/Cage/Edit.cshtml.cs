using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly ICageRepository _cageRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICategoryRepository _categoryRepository;

        public EditModel(ICageRepository cageRepository, IAuthorizationService authorizationService, ICategoryRepository categoryRepository)
        {
            _cageRepository = cageRepository;
            _authorizationService = authorizationService;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public CageDTO Cage { get; set; } = default!;

        [BindProperty]
        public List<CageComponentDTO> CageComponents { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*var policyCheck = await _authorizationService.AuthorizeAsync(User, "Staff");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }*/

            var cage = _cageRepository.GetCageById(id ?? 0);
            if (cage == null)
            {
                return NotFound();
            }
            Cage = cage;
            CageComponents = cage.CageComponents.ToList();
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            /*var policyCheck = await _authorizationService.AuthorizeAsync(User, "Staff");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }*/

            var checkCage = _cageRepository.GetCageById(Cage.CageId);
            if (checkCage == null)
            {
                return NotFound();
            }

            Cage.CageComponents = CageComponents;
            var result = _cageRepository.UpdateCage(Cage);
            if (result)
            {
                TempData["notification"] = "Update successfully";
            }
            else
            {
                TempData["notification"] = "Update failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
