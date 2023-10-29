using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages.Cage
{
    public class IndexModel : PageModel
    {
        private readonly ICageRepository _cageRepository;

        public IndexModel(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        public IList<CageDTO> Cage { get;set; } = default!;

        public void OnGet()
        {
            Cage = _cageRepository.GetAllCages();
        }
    }
}
