using System;
using System.Collections.Generic;

#nullable disable

namespace SkidEl
{
    public partial class DiscountImage
    {
        public int Id { get; set; }
        public int? DiscountId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Discount Discount { get; set; }
    }
}
