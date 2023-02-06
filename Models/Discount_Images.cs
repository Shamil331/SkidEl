namespace SkidEl.Models
{
    public class Discount_Images
    {
        public int Id { get; set; } 
        public int Discount_Id { get; set; }
        public string Image_Url { get; set; }

        public virtual Discounts Discounts { get; set; }
    }
}
