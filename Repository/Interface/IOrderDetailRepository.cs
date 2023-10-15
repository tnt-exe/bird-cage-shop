using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDTO> GetOrderDetail(int orderId);
        bool InsertOrderDetail(OrderDetailDTO orderdetailDTO);
        bool UpdateOrderDetail(OrderDetailDTO orderdetailDTO);
    }
}
