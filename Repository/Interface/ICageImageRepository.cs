using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageImageRepository
    {
        List<CageImageDTO> GetCageImages(int cageId);
        bool AddCageImage(CageImageDTO cageImageDTO);
        bool UpdateCageImage(CageImageDTO cageImageDTO);
        bool DeleteCageImage(int cageImageId);
    }
}
