using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using CageEntity = BusinessObject.Models.Cage;

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
