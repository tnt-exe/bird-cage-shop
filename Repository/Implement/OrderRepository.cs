using AutoMapper;
using BusinessObject.Models;
using DataAccessObject;
using DataTransferObject;
using Repository.Interface;

namespace Repository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ChangeOrderStatus(int orderId, int orderStatus)
            => OrderDAO.SingletonInstance.ChangeOrderStatus(orderId, orderStatus);

        public bool CreateOrder(OrderDTO orderDTO, List<OrderDetailDTO> cartItems)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cartItems)
            {
                var orderDetail = _mapper.Map<OrderDetail>(item);
                orderDetails.Add(orderDetail);
            }
            return OrderDAO.SingletonInstance.CreateOrder(order, orderDetails);
        }

        public List<OrderDTO> GetAllOrders()
        {
            List<Order> orderList = OrderDAO.SingletonInstance.GetAllOrders();
            return _mapper.Map<List<OrderDTO>>(orderList);
        }

        public List<OrderDTO> GetOrderByUser(string email)
        {
            List<Order> orderList = OrderDAO.SingletonInstance.GetOrderByUser(email);
            return _mapper.Map<List<OrderDTO>>(orderList);
        }

        public List<OrderDTO> GetOrderListByStatus(Enum orderStatus)
        {
            List<Order> orderList = OrderDAO.SingletonInstance.GetOrderListByStatus(int.Parse(orderStatus.ToString()));
            return _mapper.Map<List<OrderDTO>>(orderList);
        }
        
    }
}
