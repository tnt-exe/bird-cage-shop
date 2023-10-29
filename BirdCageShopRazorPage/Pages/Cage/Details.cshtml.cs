using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    public class DetailsModel : PageModel
    {
        private readonly ICageRepository _cageRepository;

        public DetailsModel(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        public CageDTO Cage { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
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
    }
}
