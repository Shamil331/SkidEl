using Microsoft.EntityFrameworkCore;
namespace SkidEl.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Subcategories> Subcategories { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Discount_Images> DiscountsImages { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
