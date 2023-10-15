namespace DataTransferObject
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Status { get; set; }
        public int? PaymentStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }

        public OrderDTO()
        {
        }

        public OrderDTO(
            int orderId,
            int? userId,
            decimal? totalPrice,
            int? status,
            int? paymentStatus,
            DateTime? orderDate,
            DateTime? shipDate
            )
        {
            OrderId = orderId;
            UserId = userId;
            TotalPrice = totalPrice;
            Status = status;
            PaymentStatus = paymentStatus;
            OrderDate = orderDate;
            ShipDate = shipDate;
        }
    }
}
