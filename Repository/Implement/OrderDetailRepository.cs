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

        public OrderDetailDTO getOrderDetailById(int id)
        {
            return _mapper.Map<OrderDetailDTO>(OrderDetailDAO.SingletonInstance.GetById(id));
        }

        public List<OrderDetailDTO> GetOrderDetail(int orderId)
        {
            List<OrderDetail> detailList = OrderDetailDAO.SingletonInstance.GetAll(orderId);
            return _mapper.Map<List<OrderDetailDTO>>(detailList);
        }

        public bool AddNewOrderDetail(OrderDetailDTO newEntity)
        {
            return OrderDetailDAO.SingletonInstance.AddNewOrderDetail(_mapper.Map<OrderDetail>(newEntity));
        }

        public bool UpdateOrderDetail(OrderDetailDTO update)
        {
            return OrderDetailDAO.SingletonInstance.UpdateOrderDetail(_mapper.Map<OrderDetail>(update));
        }

        public bool DeleteOrderDetail(int detailId)
        {
            return OrderDetailDAO.SingletonInstance.DeleteOrderDetail(detailId);
        }
    }
}
