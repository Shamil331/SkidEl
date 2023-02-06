using System.Collections.Generic;

namespace SkidEl.Models
{
    public class Subcategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Categorie_Id { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discounts> Discounts { get; set; }
    }
}
