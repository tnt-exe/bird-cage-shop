using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataTransferObject;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.CageComponent
{
    public class EditModel : PageModel
    {
        private readonly ICageComponentRepository _cageComponentRepository;
        private readonly ICageRepository _cageRepository;
        private readonly IComponentRepository _componentRepository;

        public EditModel(ICageComponentRepository cageComponentRepository, ICageRepository cageRepository, IComponentRepository componentRepository)
        {
            _cageComponentRepository = cageComponentRepository;
            _cageRepository = cageRepository;
            _componentRepository = componentRepository;
        }

        [BindProperty]
        public CageComponentDTO CageComponent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var cagecomponent = _cageComponentRepository.GetCageComponentById(id ?? 0);
            if (cagecomponent == null)
            {
                return NotFound();
            }
            CageComponent = cagecomponent;
           ViewData["CageId"] = new SelectList(_cageRepository.GetAllCages(), "CageId", "CageId");
           ViewData["ComponentId"] = new SelectList(_componentRepository.GetAllComponent(), "ComponentId", "ComponentId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _cageComponentRepository.UpdateCageComponent(CageComponent);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CageComponentExists(CageComponent.CageComponentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CageComponentExists(int id)
        {
          return _cageComponentRepository.GetCageComponentById(id) != null;
        }
    }
}
