﻿namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Status { get; set; }
        public int? PaymentStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
