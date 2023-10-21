using AutoMapper;
using BusinessObject.Enums;
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
            CageImage cageImg = _mapper.Map<CageImage>(cageImageDTO);
            return CageImageDAO.SingletonInstance.AddCageImage(cageImg);
        }

        public bool DeleteCageImage(int cageImageId)
        {
            return CageImageDAO.SingletonInstance.ChangeCageImgStatus(cageImageId, (byte) CageImageEnum.Deleted);
        }

        public List<CageImageDTO> GetCageImages(int cageId)
        {
            List<CageImage> cageImages = CageImageDAO.SingletonInstance.GetCageImages(cageId);
            return _mapper.Map<List<CageImageDTO>>(cageImages);
        }

        public bool UpdateCageImage(CageImageDTO cageImageDTO)
        {
            CageImage cageImg = _mapper.Map<CageImage>(cageImageDTO);
            return CageImageDAO.SingletonInstance.UpdateCageImage(cageImg);
        }
    }
}