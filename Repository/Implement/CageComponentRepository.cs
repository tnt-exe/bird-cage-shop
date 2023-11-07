using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class CageComponentRepository : ICageComponentRepository
    {
        private readonly IMapper _mapper;

        public CageComponentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CageComponentDTO> GetList()
        {
            return _mapper.Map<List<CageComponentDTO>>(CageComponentDAO.SingletonInstance.GetList());
        }

        public CageComponentDTO GetCageComponentById(int id)
        {
            return _mapper.Map<CageComponentDTO>(CageComponentDAO.SingletonInstance.GetCageComponentById(id));
        }

        public bool DeleteCageComponent(int cageComponentId)
        {
            return CageComponentDAO.SingletonInstance.DeleteCageComponent(cageComponentId);
        }

        public List<CageComponentDTO> GetComponentByCageId(int cageId)
        {
            List<CageComponent> cageComponents = CageComponentDAO.SingletonInstance.GetCageComponents(cageId);
            return _mapper.Map<List<CageComponentDTO>>(cageComponents);
        }

        public bool InsertCageComponent(List<CageComponentDTO> cageComponentList)
        {
            List<CageComponent> componentList = new List<CageComponent>();
            foreach (var item in cageComponentList)
            {
                var component = _mapper.Map<CageComponent>(item);
                componentList.Add(component);
            }
            return CageComponentDAO.SingletonInstance.InsertCageComponent(componentList);
        }

        public bool UpdateCageComponent(CageComponentDTO cageComponentDTO)
        {
            CageComponent cageComponent = _mapper.Map<CageComponent>(cageComponentDTO);
            return CageComponentDAO.SingletonInstance.UpdateCageComponent(cageComponent);
        }

        public bool IsCageComponentRequired(int cageComponentId)
        {
            return CageComponentDAO.SingletonInstance.IsCageComponentRequired(cageComponentId);
        }
    }
}
