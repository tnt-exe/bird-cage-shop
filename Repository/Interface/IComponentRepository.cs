using DataTransferObject;

namespace Repository.Interface
{
    public interface IComponentRepository
    {
        List<ComponentDTO> GetAllComponent();
        List<ComponentDTO> GetSearchComponent(string keyword);
        ComponentDTO GetComponentById(int id);
    }
}
