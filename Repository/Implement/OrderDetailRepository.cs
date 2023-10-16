using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;

        public OrderDetailRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<OrderDetailDTO> GetOrderDetail(int orderId)
        {
            List<OrderDetail> detailList = OrderDetailDAO.SingletonInstance.GetAll(orderId);
            return _mapper.Map<List<OrderDetailDTO>>(detailList);
        }
    }
}
