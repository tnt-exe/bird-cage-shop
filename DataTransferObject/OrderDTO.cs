﻿namespace DataTransferObject
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

        public ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();

        public OrderDTO()
        {
        }
    }
}
