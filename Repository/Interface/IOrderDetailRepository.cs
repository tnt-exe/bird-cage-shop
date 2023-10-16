using DataTransferObject;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDTO> GetOrderDetail(int orderId);
    }
}
