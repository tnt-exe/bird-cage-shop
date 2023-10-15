﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class CageComponent
    {
        public int CageComponentId { get; set; }
        public int? ComponentId { get; set; }
        public int? CageId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Cage? Cage { get; set; }
        public virtual Component? Component { get; set; }
    }
}
