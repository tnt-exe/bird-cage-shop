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
    public class DetailsModel : PageModel
    {
        private readonly ICageComponentRepository _cageComponentRepository;

        public DetailsModel(ICageComponentRepository cageComponentRepository)
        {
            _cageComponentRepository = cageComponentRepository;
        }

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
    }
}
