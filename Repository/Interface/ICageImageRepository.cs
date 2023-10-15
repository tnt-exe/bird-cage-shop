using DataTransferObject;

namespace Repository.Interface
{
    public interface ICageImageRepository
    {
        IEnumerable<CageImageDTO> GetCageImages(int cageId);
    }
}
