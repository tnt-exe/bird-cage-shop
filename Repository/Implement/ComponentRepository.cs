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
            List<Component> componentList = ComponentDAO.SingletonInstance.GetSearchComponents(keyword);
            return _mapper.Map<List<ComponentDTO>>(componentList);
        }

        public bool AddComponent(ComponentDTO component)
        {
            return ComponentDAO.SingletonInstance.AddComponent(_mapper.Map<Component>(component));
        }

        public bool UpdateComponent(ComponentDTO component)
        {
            return ComponentDAO.SingletonInstance.UpdateComponent(_mapper.Map<Component>(component));
        }

        public bool DeleteComponent(int componentId)
        {
            return ComponentDAO.SingletonInstance.DeleteComponent(componentId);
        }
    }
}
