using DataTransferObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;

namespace BirdCageShopRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICageRepository _cageRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ICageRepository cageRepository)
        {
            _logger = logger;
            _cageRepository = cageRepository;
        }

        public IList<CageDTO> Cage { get; set; } = default!;

        public void OnGetAsync()
        {
            Cage = _cageRepository.GetAllCages();
        }
    }
}