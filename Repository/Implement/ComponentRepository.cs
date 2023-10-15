using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class ComponentRepository : IComponentRepository
    {
        public List<ComponentDTO> GetAllComponent()
        {
            throw new NotImplementedException();
        }

        public ComponentDTO GetComponentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ComponentDTO> GetSearchComponent(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
