using BusinessObject.Models;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailDTO> GetOrderDetail(int orderId);
        bool InsertOrderDetail(OrderDetailDTO orderdetail);
        bool UpdateOrderDetail(OrderDetailDTO orderdetail);
    }
}
