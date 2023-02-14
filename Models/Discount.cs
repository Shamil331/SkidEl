using System;
using System.Collections.Generic;

#nullable disable

namespace SkidEl
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountImages = new HashSet<DiscountImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ShopId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SubcategoryId { get; set; }
        public string Description { get; set; }
        public int? PreviousPrice { get; set; }
        public int? NowPrice { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<DiscountImage> DiscountImages { get; set; }
    }
}
