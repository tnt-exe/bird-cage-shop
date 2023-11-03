using AutoMapper;
using BusinessObject.Enums;
using BusinessObject.Models;
using DataTransferObject;

namespace Repository.Mapper
{
    public class AutoMapperConfigure : Profile
    {
        public AutoMapperConfigure()
        {
            CreateMap<Cage, CageDTO>()
                //.ForMember(dest => dest.Status, options => options.MapFrom(src => Enum.GetName(typeof(CageStatus), src.Status ?? -1)))
                .ForMember(dest => dest.CageComponents, options => options.MapFrom(src => src.CageComponents))
                .ReverseMap()
                .ForMember(dest => dest.CageComponents, options => options.MapFrom(src => src.CageComponents));
                //.ForMember(dest => dest.Status, options => options.MapFrom(src => (int)(CageStatus)Enum.Parse(typeof(CageStatus), src.Status ?? "Undefined")));

            CreateMap<CageComponent, CageComponentDTO>().ReverseMap();
            CreateMap<CageImage, CageImageDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Component, ComponentDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Status, options => options.MapFrom(src => Enum.GetName(typeof(OrderStatus), src.Status ?? -1)))
                .ForMember(dest => dest.PaymentStatus, options => options.MapFrom(src => Enum.GetName(typeof(PaymentStatus), src.PaymentStatus ?? -1)))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ReverseMap()
                .ForMember(dest => dest.Status, options => options.MapFrom(src => (int)(OrderStatus)Enum.Parse(typeof(OrderStatus), src.Status ?? "Undefined")))
                .ForMember(dest => dest.PaymentStatus, options => options.MapFrom(src => (int)(PaymentStatus)Enum.Parse(typeof(PaymentStatus), src.PaymentStatus ?? "None")))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
