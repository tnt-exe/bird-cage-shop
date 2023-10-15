using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetAllOrders();
        bool CreateOrder(OrderDTO orderDTO);
        bool ChangeOrderStatus(int orderId, int orderStatus);
        bool Reorder(int orderId);
        List<OrderDTO> GetOrderByUser(string email);
        List<OrderDTO> GetOrderListByStatus(Enum orderStatus);
    }
}
