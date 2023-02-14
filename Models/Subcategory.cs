using System;
using System.Collections.Generic;

#nullable disable

namespace SkidEl
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Discounts = new HashSet<Discount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategorieId { get; set; }

        public virtual Category Categorie { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
