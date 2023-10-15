using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cage
    {
        public Cage()
        {
            CageComponents = new HashSet<CageComponent>();
            CageImages = new HashSet<CageImage>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CageId { get; set; }
        public string? CageName { get; set; }
        public int? Status { get; set; }
        public decimal? CagePrice { get; set; }
        public int? CageSize { get; set; }
        public int? CageWeight { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CageComponent> CageComponents { get; set; }
        public virtual ICollection<CageImage> CageImages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
