using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ICageRepository _cageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IAuthorizationService _authorizationService;

        public CreateModel(ICageRepository cageRepository,
            ICategoryRepository categoryRepository,
            IComponentRepository componentRepository,
            IAuthorizationService authorizationService)
        {
            _cageRepository = cageRepository;
            _categoryRepository = categoryRepository;
            _componentRepository = componentRepository;
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> OnGet()
        {
            var policyCheck = await _authorizationService.AuthorizeAsync(User, "Staff");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }

            var components = _componentRepository.GetAllComponent();
            foreach (var item in components)
            {
                var cageComponent = new CageComponentDTO
                {
                    ComponentId = item.ComponentId,
                    Component = item,
                };

                switch (item.ComponentName)
                {
                    case "Đáy":
                        cageComponent.Quantity = 2;
                        cageComponent.Price = 2 * item.ComponentPrice;
                        break;

                    case "Trụ":
                        cageComponent.Quantity = 2;
                        cageComponent.Price = 2 * item.ComponentPrice;
                        break;

                    case "Móc":
                        cageComponent.Quantity = 1;
                        cageComponent.Price = item.ComponentPrice;
                        break;

                    case "Cửa":
                        cageComponent.Quantity = 2;
                        cageComponent.Price = 2 * item.ComponentPrice;
                        break;

                    case "Nan":
                        cageComponent.Quantity = 50;
                        cageComponent.Price = 50 * item.ComponentPrice;
                        break;
                }

                CageComponents.Add(cageComponent);
            }
            ViewData["CageStatus"] = new SelectList(new string[] { "Unavailable", "Available" });
            ViewData["CategoryId"] = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public CageDTO Cage { get; set; } = default!;

        [BindProperty]
        public List<CageComponentDTO> CageComponents { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var policyCheck = await _authorizationService.AuthorizeAsync(User, "Staff");
            if (!policyCheck.Succeeded)
            {
                return RedirectToPage("/Forbidden");
            }

            if (Cage.Status is null)
            {
                Cage.Status = "Custom";
            }

            Cage.CageComponents = CageComponents;
            var result = _cageRepository.AddNewCage(Cage);

            if (result)
            {
                TempData["notification"] = "Create new cage successfully";
            }
            else
            {
                TempData["notification"] = "Create new cage failed";
            }

            return RedirectToPage("./Index");
        }
    }
}
