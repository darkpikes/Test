using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductTest.Entities
{
    public partial class ProductTestContext : DbContext
    {
        public ProductTestContext()
        {
        }

        public ProductTestContext(DbContextOptions<ProductTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Upc)
                    .HasName("PRIMARY");

                entity.Property(e => e.Upc)
                    .HasColumnType("int(11)")
                    .HasColumnName("UPC");

                entity.Property(e => e.CurrentPrice)
                    .HasPrecision(10)
                    .HasColumnName("currentPrice");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
