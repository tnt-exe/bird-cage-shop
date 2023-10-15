using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? CageId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Cage? Cage { get; set; }
        public virtual Order? Order { get; set; }
    }
}
