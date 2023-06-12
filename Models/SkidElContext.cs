using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SkidEl
{
    public partial class SkidElContext : DbContext
    {
        public SkidElContext()
        {
        }

        public SkidElContext(DbContextOptions<SkidElContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountImage> DiscountImages { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost; Database=SkidEl; Username=postgres; Password=Shamil25");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discounts");

                entity.HasIndex(e => e.Link, "uniq_link")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NowPrice).HasColumnName("now_price");

                entity.Property(e => e.PreviousPrice).HasColumnName("previous_price");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("fk_shopdiscount");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("fk_subcategorydiscount");
            });

            modelBuilder.Entity<DiscountImage>(entity =>
            {
                entity.ToTable("discount_images");

                entity.HasIndex(e => e.DiscountLink, "fki_fk_discountsdiscount_images");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.HasOne(d => d.DiscountLinkNavigation)
                    .WithMany(p => p.DiscountImages)
                    .HasPrincipalKey(p => p.Link)
                    .HasForeignKey(d => d.DiscountLink)
                    .HasConstraintName("fk_discountsdiscount_images");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shops");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Link).HasColumnName("link");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PreviewUrl).HasColumnName("preview_url");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CategorieId).HasColumnName("categorie_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("fk_categoriesubcategorie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
