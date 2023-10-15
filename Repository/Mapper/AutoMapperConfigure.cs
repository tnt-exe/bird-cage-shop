using AutoMapper;
using BusinessObject.Models;
using DataTransferObject;

namespace Repository.Mapper
{
    public class AutoMapperConfigure : Profile
    {
        public AutoMapperConfigure()
        {
            CreateMap<Cage, CageDTO>().ReverseMap();
            CreateMap<CageComponent, CageComponentDTO>().ReverseMap();
            CreateMap<CageImage, CageImageDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Component, ComponentDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
