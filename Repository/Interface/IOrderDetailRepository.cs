using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDTO> GetOrderDetail(int orderId);

        bool AddNewOrderDetail(OrderDetailDTO newEntity);

        bool UpdateOrderDetail(OrderDetailDTO update);

        OrderDetailDTO getOrderDetailById(int id);
    }
}
