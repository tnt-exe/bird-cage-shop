using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class CageImageRepository : ICageImageRepository
    {
        private readonly IMapper _mapper;

        public CageImageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AddCageImage(CageImageDTO cageImageDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCageImage(int cageImageId)
        {
            throw new NotImplementedException();
        }

        public List<CageImageDTO> GetCageImages(int cageId)
        {
            List<CageImage> cageImages = CageImageDAO.SingletonInstance.GetCageImages(cageId);
            return _mapper.Map<List<CageImageDTO>>(cageImages);
        }

        public bool UpdateCageImage(CageImageDTO cageImageDTO)
        {
            throw new NotImplementedException();
        }
    }
}
