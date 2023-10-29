using AutoMapper;
using BusinessObject.Enums;
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

        public OrderDTO GetOrderById(int id)
        {
            return _mapper.Map<OrderDTO>(OrderDAO.SingletonInstance.GetOrderById(id));
        }

        public bool UpdateOrder(Order updateOrder)
        {
            return OrderDAO.SingletonInstance.UpdateOrder(updateOrder);
        }

        public Order? GetLatestSuitableOrderOfUser(int userId)
        {
            // Lấy order đang trong trạng thái waiting
            // Lấy order của user theo userId
            // Lấy order mới đc tạo gần đây

            var status = (int)(OrderStatus)Enum.Parse(typeof(OrderStatus), "Waiting");
            return OrderDAO.SingletonInstance.GetSuiatbleOrder(userId, status);
        }

        public bool ChangeOrderStatus(int orderId, int orderStatus)
            => OrderDAO.SingletonInstance.ChangeOrderStatus(orderId, orderStatus);

        public bool CreateOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            return OrderDAO.SingletonInstance.CreateOrder(order);
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
