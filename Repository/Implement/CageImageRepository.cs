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
    public class CageImageRepository : ICageImageRepository
    {
        private readonly IMapper _mapper;

        public CageImageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<CageImageDTO> GetCageImages(int cageId)
        {
            throw new NotImplementedException();
        }
    }
}
