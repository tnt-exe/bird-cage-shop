using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? CageId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public OrderDetailDTO()
        {
        }

        public OrderDetailDTO(int orderDetailId, int? orderId, int? cageId, decimal? price, int? quantity)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            CageId = cageId;
            Price = price;
            Quantity = quantity;
        }
    }
}
