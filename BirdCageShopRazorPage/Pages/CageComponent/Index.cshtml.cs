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
    public class IndexModel : PageModel
    {
        private readonly ICageComponentRepository _cageComponentRepository;

        public IndexModel(ICageComponentRepository cageComponentRepository)
        {
            _cageComponentRepository = cageComponentRepository;
        }

        public IList<CageComponentDTO> CageComponent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CageComponent = _cageComponentRepository.GetList();
        }
    }
}
