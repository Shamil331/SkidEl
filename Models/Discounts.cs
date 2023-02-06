using System;
using System.Collections.Generic;
using System.Text;
namespace SkidEl.Models
{
    public class Discounts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Shop_Id { get; set; }
        public Nullable<DateTime> Start_Date { get; set; }
        public Nullable<DateTime> End_Date { get; set; }
        public int Subcategory_Id { get; set; }
        public string Description { get; set; }
        public int Previous_Price { get; set; }
        public int New_Price { get; set; }

        
        public virtual Shops Shops { get; set; }

        public virtual Subcategories Subcategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount_Images> Discount_Images { get; set; }
    }
}
