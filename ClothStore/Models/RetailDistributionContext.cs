using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClothStore.Models
{
    public partial class RetailDistributionContext : DbContext
    {
        public RetailDistributionContext(DbContextOptions<RetailDistributionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<ClothColor> ClothColors { get; set; } = null!;
        public virtual DbSet<ClothStock> ClothStocks { get; set; } = null!;
        public virtual DbSet<ClothType> ClothTypes { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClothColor>(entity =>
            {
                entity.ToTable("ClothColor");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClothStock>(entity =>
            {
                entity.HasKey(e => e.ClothId)
                    .HasName("PK__ClothSto__5592954FAAC6FA00");

                entity.ToTable("ClothStock");

                entity.Property(e => e.ClothsInStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BrandNameNavigation)
                    .WithMany(p => p.ClothStocks)
                    .HasForeignKey(d => d.BrandName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClothStoc__Brand__2D27B809");

                entity.HasOne(d => d.ClothSizeNavigation)
                    .WithMany(p => p.ClothStocks)
                    .HasForeignKey(d => d.ClothSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClothStoc__Cloth__2E1BDC42");

                entity.HasOne(d => d.ColorOfClothNavigation)
                    .WithMany(p => p.ClothStocks)
                    .HasForeignKey(d => d.ColorOfCloth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClothStoc__Color__300424B4");

                entity.HasOne(d => d.TypeOfClothNavigation)
                    .WithMany(p => p.ClothStocks)
                    .HasForeignKey(d => d.TypeOfCloth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClothStoc__TypeO__2F10007B");
            });

            modelBuilder.Entity<ClothType>(entity =>
            {
                entity.ToTable("ClothType");

                entity.Property(e => e.ClothTypes)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ClothType");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.ClothSize)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
