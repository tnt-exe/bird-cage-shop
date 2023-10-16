using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetAllOrders();
        bool CreateOrder(OrderDTO orderDTO, List<OrderDetailDTO> cartItems);
        bool ChangeOrderStatus(int orderId, int orderStatus);
        List<OrderDTO> GetOrderByUser(string email);
        List<OrderDTO> GetOrderListByStatus(Enum orderStatus);
    }
}
