using System;
using System.Collections.Generic;

#nullable disable

namespace SkidEl
{
    public partial class Shop
    {
        public Shop()
        {
            Discounts = new HashSet<Discount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string PreviewUrl { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
