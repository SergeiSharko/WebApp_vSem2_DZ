using Microsoft.EntityFrameworkCore;
using WebApp_vSem2.Models;

namespace WebApp_vSem2.Data
{
    public class WebAppContext(string _dbConnectionString) : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.LogTo(Console.WriteLine)
                          .UseLazyLoadingProxies()
                          .UseMySql(_dbConnectionString, ServerVersion.AutoDetect(_dbConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(pq => pq.Id)
                      .HasName("product_group_pk");

                entity.ToTable("Category");

                entity.Property(pq => pq.Name)
                      .HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id)
                       .HasName("product_pk");

                entity.Property(p => p.Name)
                      .HasMaxLength(255);

                entity.HasOne(p => p.ProductGroup)
                      .WithMany(p => p.Products)
                      .HasForeignKey(p => p.ProductGroupId);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(s => s.Id)
                      .HasName("storage_pk");

                entity.HasOne(s => s.Product)
                      .WithMany(p => p.Storages)
                      .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
