using AutoMapper;
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
            throw new NotImplementedException();
        }

        public bool InsertOrderDetail(OrderDetailDTO orderdetailDTO)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrderDetail(OrderDetailDTO orderdetailDTO)
        {
            throw new NotImplementedException();
        }
    }
}
