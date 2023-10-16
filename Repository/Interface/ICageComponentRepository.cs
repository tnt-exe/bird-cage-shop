using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageComponentRepository
    {
        List<CageComponentDTO> GetComponentByCageId(int cageId);
        bool InsertCageComponent(List<CageComponentDTO> cageComponentList);
        bool UpdateCageComponent(CageComponentDTO cageComponentDTO);
        bool DeleteCageComponent(int cageComponentId);
    }
}
