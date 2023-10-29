using BusinessObject.Models;
using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        OrderDTO GetOrderById(int id);
        List<OrderDTO> GetAllOrders();
        bool CreateOrder(OrderDTO orderDTO);
        bool ChangeOrderStatus(int orderId, int orderStatus);
        List<OrderDTO> GetOrderByUser(string email);
        List<OrderDTO> GetOrderListByStatus(Enum orderStatus);
        Order? GetLatestSuitableOrderOfUser(int userId);
        bool UpdateOrder(Order updateOrder);
    }
}
