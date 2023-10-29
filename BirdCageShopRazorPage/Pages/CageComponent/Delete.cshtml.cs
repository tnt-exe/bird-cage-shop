using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataTransferObject;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.CageComponent
{
    public class DeleteModel : PageModel
    {
        private readonly ICageComponentRepository _cageComponentRepository;

        public DeleteModel(ICageComponentRepository cageComponentRepository)
        {
            _cageComponentRepository = cageComponentRepository;
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
            else 
            {
                CageComponent = cagecomponent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var result = _cageComponentRepository.DeleteCageComponent(id ?? 0);

            if (result)
            {

            }
            else
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
