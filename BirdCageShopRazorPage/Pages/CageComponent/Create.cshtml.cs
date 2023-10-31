using AutoMapper;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirdCageShopRazorPage.Pages.CageComponent
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.BirdCageShopContext _context;
        private readonly IMapper _mapper;

        public CreateModel(BusinessObject.Models.BirdCageShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CageId"] = new SelectList(_context.Cages, "CageId", "CageId");
            ViewData["ComponentId"] = new SelectList(_context.Components, "ComponentId", "ComponentId");
            return Page();
        }

        [BindProperty]
        public CageComponentDTO CageComponent { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.CageComponents == null || CageComponent == null)
            {
                return Page();
            }

            _context.CageComponents.Add(_mapper.Map<BusinessObject.Models.CageComponent>(CageComponent));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
