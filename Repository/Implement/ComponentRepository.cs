using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly IMapper _mapper;

        public ComponentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ComponentDTO> GetAllComponent()
        {
            List<Component> componentList = ComponentDAO.SingletonInstance.GetAllComponent();
            return _mapper.Map<List<ComponentDTO>>(componentList);
        }

        public ComponentDTO GetComponentById(int id)
        {
            Component component = ComponentDAO.SingletonInstance.GetComponentById(id);
            return _mapper.Map<ComponentDTO>(component);
        }

        public List<ComponentDTO> GetSearchComponent(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
