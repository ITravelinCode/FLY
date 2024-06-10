using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FLY.DataAccess.Entities;

public partial class FlyContext : DbContext
{
    public FlyContext()
    {
    }

    public FlyContext(DbContextOptions<FlyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<VoucherOfshop> VoucherOfshops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-MQ52Q21P\\MSSQLSERVER01;Initial Catalog=FLY;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Address).HasMaxLength(30);
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("blogId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.BlogContent)
                .HasMaxLength(350)
                .HasColumnName("blogContent");
            entity.Property(e => e.BlogDate).HasColumnName("blogDate");
            entity.Property(e => e.BlogImage)
                .HasMaxLength(250)
                .HasColumnName("blogImage");
            entity.Property(e => e.BlogName)
                .HasMaxLength(50)
                .HasColumnName("blogName");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Blog_Account");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CartQuantity).HasColumnName("cartQuantity");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Account");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Cart_Product");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .HasColumnName("content");
            entity.Property(e => e.ShopId).HasColumnName("shopId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Feedback_Account");

            entity.HasOne(d => d.Shop).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Shop");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Order_Account");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("orderDetailId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_Account");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ImageProduct)
                .HasMaxLength(250)
                .HasColumnName("imageProduct");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.ProductInfor)
                .HasMaxLength(250)
                .HasColumnName("productInfor");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            entity.Property(e => e.ProductQuatity)
                .HasColumnType("datetime")
                .HasColumnName("productQuatity");
            entity.Property(e => e.ShopId).HasColumnName("shopId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VoucherId).HasColumnName("voucherId");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK_Product_pRODUCTcATEGORY");

            entity.HasOne(d => d.Shop).WithMany(p => p.Products)
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK_Product_Shop");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Products)
                .HasForeignKey(d => d.VoucherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Voucher");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.ImageProduct)
                .HasMaxLength(250)
                .HasColumnName("imageProduct");
            entity.Property(e => e.ProductCategoryName)
                .HasMaxLength(50)
                .HasColumnName("productCategoryName");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RateId);

            entity.ToTable("Rating");

            entity.Property(e => e.RateId).HasColumnName("rateId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.RateNumber).HasColumnName("rateNumber");
            entity.Property(e => e.ShopId).HasColumnName("shopId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Rating_Account");

            entity.HasOne(d => d.Shop).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_Shop");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId);

            entity.ToTable("RefreshToken");

            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("deviceName");
            entity.Property(e => e.ExpiredDate)
                .HasColumnType("datetime")
                .HasColumnName("expiredDate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Token)
                .IsUnicode(false)
                .HasColumnName("token");

            entity.HasOne(d => d.Account).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_RefreshToken_Account");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.ShopId).HasColumnName("shopId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.ShopAddress)
                .HasMaxLength(250)
                .HasColumnName("shopAddress");
            entity.Property(e => e.ShopDetail)
                .HasMaxLength(250)
                .HasColumnName("shopDetail");
            entity.Property(e => e.ShopEndTime)
                .HasColumnType("datetime")
                .HasColumnName("shopEndTime");
            entity.Property(e => e.ShopName)
                .HasMaxLength(50)
                .HasColumnName("shopName");
            entity.Property(e => e.ShopStartTime)
                .HasColumnType("datetime")
                .HasColumnName("shopStartTime");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Shops)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Shop_Account");
        });

        modelBuilder.Entity<VoucherOfshop>(entity =>
        {
            entity.HasKey(e => e.VoucherId);

            entity.ToTable("VoucherOFShop");

            entity.Property(e => e.VoucherId).HasColumnName("voucherId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VoucherEnd)
                .HasColumnType("datetime")
                .HasColumnName("voucherEnd");
            entity.Property(e => e.VoucherName)
                .HasMaxLength(50)
                .HasColumnName("voucherName");
            entity.Property(e => e.VoucherStart)
                .HasColumnType("datetime")
                .HasColumnName("voucherStart");
            entity.Property(e => e.VoucherValue).HasColumnName("voucherValue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
