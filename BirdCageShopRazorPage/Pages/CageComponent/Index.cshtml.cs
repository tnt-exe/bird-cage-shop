using DataTransferObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<CageComponentDTO> CageComponent { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CageComponent = _cageComponentRepository.GetList();
        }
    }
}
