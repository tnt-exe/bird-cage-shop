using AutoMapper;
using DataTransferObject;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public bool ChangeCageStatus(CageDTO cageDTO, int status)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCage(CageDTO cageDTO)
        {
            throw new NotImplementedException();
        }

        public List<CageDTO> GetAllCages()
        {
            throw new NotImplementedException();
        }

        public CageDTO GetCageById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CageDTO> GetCagesByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<CageDTO> GetCagesByStatus(int status)
        {
            throw new NotImplementedException();
        }

        public List<CageDTO> GetSearchCages(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<CageDTO> GetTopCages(int top)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCage(CageDTO cageDTO)
        {
            throw new NotImplementedException();
        }
    }
}
