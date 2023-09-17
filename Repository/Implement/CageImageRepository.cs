using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class CageImageRepository : ICageImageRepository
    {
        private readonly IMapper _mapper;

        public CageImageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<CageImageDTO> GetCageImages(int cageId)
        {
            IEnumerable<CageImage> cageImages = CageImageDAO.SingletonInstance.GetCageImages(cageId);
            return _mapper.Map<IEnumerable<CageImageDTO>>(cageImages);
        }
    }
}
