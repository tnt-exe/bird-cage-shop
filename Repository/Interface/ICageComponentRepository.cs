using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageComponentRepository
    {
        CageComponentDTO GetCageComponentById(int id);
        bool IsCageComponentRequired(int cageComponentId);
        List<CageComponentDTO> GetComponentByCageId(int cageId);
        bool InsertCageComponent(List<CageComponentDTO> cageComponentList);
        bool UpdateCageComponent(CageComponentDTO cageComponentDTO);
        bool DeleteCageComponent(int cageComponentId);
        List<CageComponentDTO> GetList();
    }
}
