using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cage
    {
        public Cage()
        {
            CageImages = new HashSet<CageImage>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CageId { get; set; }
        public int? CategoryId { get; set; }
        public string? CageName { get; set; }
        public int? Quantity { get; set; }
        public string? Material { get; set; }
        public int? Status { get; set; }
        public double? Price { get; set; }
        public string? Color { get; set; }
        public int? Rating { get; set; }
        public int? Size { get; set; }
        public int? Weight { get; set; }
        public string? Description { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CageImage> CageImages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
