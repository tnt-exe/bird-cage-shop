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

        public bool DeleteCageComponent(int cageComponentId)
        {
            throw new NotImplementedException();
        }

        public List<CageComponentDTO> GetComponentByCageId(int cageId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
