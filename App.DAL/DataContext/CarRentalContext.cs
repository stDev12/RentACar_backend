using System;
using System.Collections.Generic;
using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.DataContext;

public partial class CarRentalContext : DbContext
{
    public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Extra> Extras { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Cars__68A0340EB44C28D8");

            entity.HasIndex(e => e.CarName, "UQ__Cars__DEACC3EFED538850").IsUnique();

            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CarName).HasMaxLength(50);
            entity.Property(e => e.CarType).HasMaxLength(10);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ImagePath).HasMaxLength(100);
            entity.Property(e => e.Info).HasMaxLength(500);
            entity.Property(e => e.Rating).HasColumnType("numeric(3, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Cars__CategoryID__46E78A0C");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B64BE5AAB");

            entity.HasIndex(e => e.CategoryName, "UQ__Categori__8517B2E02983BE9A").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
        });

        modelBuilder.Entity<Extra>(entity =>
        {
            entity.HasKey(e => e.ExtraId).HasName("PK__Extras__D1F3A807E8AB021E");

            entity.Property(e => e.ExtraId).HasColumnName("ExtraID");
            entity.Property(e => e.ExtraName).HasMaxLength(30);
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFBE8C2B07");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserID__5441852A");

            entity.HasMany(d => d.Rentals).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderRental",
                    r => r.HasOne<Rental>().WithMany()
                        .HasForeignKey("RentalId")
                        .HasConstraintName("FK__OrderRent__Renta__5AEE82B9"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderRent__Order__59FA5E80"),
                    j =>
                    {
                        j.HasKey("OrderId", "RentalId");
                        j.ToTable("OrderRentals");
                        j.IndexerProperty<int>("OrderId").HasColumnName("OrderID");
                        j.IndexerProperty<int>("RentalId").HasColumnName("RentalID");
                    });
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rentals__9700596339334EB1");

            entity.Property(e => e.RentalId).HasColumnName("RentalID");
            entity.Property(e => e.CarId).HasColumnName("CarID");

            entity.HasOne(d => d.Car).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rentals__CarID__571DF1D5");

            entity.HasMany(d => d.Extras).WithMany(p => p.Rentals)
                .UsingEntity<Dictionary<string, object>>(
                    "RentalExtra",
                    r => r.HasOne<Extra>().WithMany()
                        .HasForeignKey("ExtraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RentalExt__Extra__5EBF139D"),
                    l => l.HasOne<Rental>().WithMany()
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__RentalExt__Renta__5DCAEF64"),
                    j =>
                    {
                        j.HasKey("RentalId", "ExtraId");
                        j.ToTable("RentalExtras");
                        j.IndexerProperty<int>("RentalId").HasColumnName("RentalID");
                        j.IndexerProperty<int>("ExtraId").HasColumnName("ExtraID");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3ADA968C87");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160B43A9BD0").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(15);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__Shopping__488B0B2A57D4C6AA");

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CartItemId).HasColumnName("CartItemID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Car).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__CarID__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__UserI__4CA06362");

            entity.HasMany(d => d.Extras).WithMany(p => p.CartItems)
                .UsingEntity<Dictionary<string, object>>(
                    "CartExtra",
                    r => r.HasOne<Extra>().WithMany()
                        .HasForeignKey("ExtraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CartExtra__Extra__5165187F"),
                    l => l.HasOne<ShoppingCart>().WithMany()
                        .HasForeignKey("CartItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CartExtra__CartI__5070F446"),
                    j =>
                    {
                        j.HasKey("CartItemId", "ExtraId");
                        j.ToTable("CartExtras");
                        j.IndexerProperty<int>("CartItemId").HasColumnName("CartItemID");
                        j.IndexerProperty<int>("ExtraId").HasColumnName("ExtraID");
                    });
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__Tokens__658FEE8A39699AB6");

            entity.Property(e => e.TokenId)
                .ValueGeneratedNever()
                .HasColumnName("TokenID");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.TokenJwt)
                .HasMaxLength(500)
                .HasColumnName("TokenJWT");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tokens__UserID__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC060A0EA0");

            entity.HasIndex(e => e.Idnumber, "UQ__Users__564DB08A3B00BCEA").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreatedAT");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(9)
                .HasColumnName("IDNumber");
            entity.Property(e => e.LicenseNumber).HasMaxLength(7);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName).HasMaxLength(30);
            entity.Property(e => e.UserPassword).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
