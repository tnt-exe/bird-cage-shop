using AutoMapper;
using BusinessObject.Enums;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class CageRepository : ICageRepository
    {
        private readonly IMapper _mapper;

        public CageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AddNewCage(CageDTO cageDTO)
        {
            Cage cage = _mapper.Map<Cage>(cageDTO);
            return CageDAO.SingletonInstance.AddNewCage(cage);
        }

        public bool ChangeCageStatus(CageDTO cageDTO, int status)
        {
            Cage cage = _mapper.Map<Cage>(cageDTO);
            return CageDAO.SingletonInstance.ChangeCageStatus(cage, status);
        }

        public bool DeleteCage(CageDTO cageDTO)
        {
            Cage cage = _mapper.Map<Cage>(cageDTO);
            return CageDAO.SingletonInstance.ChangeCageStatus(cage, (int)CageStatus.Unavailable);
        }

        public List<CageDTO> GetAllCages()
        {
            List<Cage> cagesList = CageDAO.SingletonInstance.GetAllCages();
            return _mapper.Map<List<CageDTO>>(cagesList);
        }

        public CageDTO GetCageById(int id)
        {
            Cage cage = CageDAO.SingletonInstance.GetCageById(id);
            return _mapper.Map<CageDTO>(cage);
        }

        public List<CageDTO> GetCagesByCategory(int categoryId)
        {
            List<Cage> cagesList = CageDAO.SingletonInstance.GetCagesByCategory(categoryId);
            return _mapper.Map<List<CageDTO>>(cagesList);
        }

        public List<CageDTO> GetCagesByStatus(int status)
        {
            List<Cage> cagesList = CageDAO.SingletonInstance.GetCagesByStatus(status);
            return _mapper.Map<List<CageDTO>>(cagesList);
        }

        public List<CageDTO> GetSearchCages(string keyword)
        {
            List<Cage> cagesList = CageDAO.SingletonInstance.GetSearchCages(keyword);
            return _mapper.Map<List<CageDTO>>(cagesList);
        }

        public List<CageDTO> GetTopCages(int top)
        {
            List<Cage> cagesList = CageDAO.SingletonInstance.GetTopCages(top);
            return _mapper.Map<List<CageDTO>>(cagesList);
        }

        public bool UpdateCage(CageDTO cageDTO)
        {
            Cage cage = _mapper.Map<Cage>(cageDTO);
            return CageDAO.SingletonInstance.UpdateCage(cage);
        }

        public bool RemoveCage(int id)
        {
            return CageDAO.SingletonInstance.RemoveCage(id);
        }
    }
}
