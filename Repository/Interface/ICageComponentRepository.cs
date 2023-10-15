using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageComponentRepository
    {
        List<CageComponentDTO> GetComponentByCageId(int cageId);
        bool InsertCageComponent(CageComponentDTO cageComponentDTO);
        bool UpdateCageComponent(CageComponentDTO cageComponentDTO);
        bool DeleteCageComponent(int cageComponentId);
    }
}
