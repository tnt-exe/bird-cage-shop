using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDTO> GetOrderDetail(int orderId);

        bool AddNewOrderDetail(OrderDetailDTO newEntity);

        bool UpdateOrderDetail(OrderDetailDTO update);

        bool DeleteOrderDetail(int detailId);

        OrderDetailDTO getOrderDetailById(int id);
    }
}
