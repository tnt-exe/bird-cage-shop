using BusinessObject.Enums;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICageRepository _cageRepository;

        public IndexModel(ICageRepository cageRepository)
        {
            _cageRepository = cageRepository;
        }

        public IList<CageDTO> Cage { get; set; } = default!;

        public void OnGet()
        {
            var cageList = _cageRepository.GetAllCages();
            Cage = cageList.Where(cage => cage.Status == (int)CageStatus.Available).ToList();
        }
    }
}