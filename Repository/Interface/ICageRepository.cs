using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageRepository
    {
        bool AddNewCage(CageDTO cageDTO);
        bool UpdateCage(CageDTO cageDTO);
        bool DeleteCage(CageDTO cageDTO);
        bool ChangeCageStatus(CageDTO cageDTO, int status);
        List<CageDTO> GetAllCages();
        List<CageDTO> GetCagesByStatus(int status);
        List<CageDTO> GetSearchCages(string keyword);
        List<CageDTO> GetCagesByCategory(int categoryId);
        List<CageDTO> GetTopCages(int top);
        CageDTO GetCageById(int id);
        bool RemoveCage(int id);
    }
}
