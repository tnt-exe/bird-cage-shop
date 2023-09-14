using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public double? Total { get; set; }
        public int? Status { get; set; }
        public int? PaymentStatus { get; set; }

        public OrderDTO()
        {
        }

        public OrderDTO(int orderId, int? userId, double? total, int? status, int? paymentStatus)
        {
            OrderId = orderId;
            UserId = userId;
            Total = total;
            Status = status;
            PaymentStatus = paymentStatus;
        }
    }
}
