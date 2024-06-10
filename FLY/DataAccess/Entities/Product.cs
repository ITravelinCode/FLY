using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public int ShopId { get; set; }

    public int? VoucherId { get; set; }

    public int ProductCategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductInfor { get; set; } = null!;

    public double ProductPrice { get; set; }

    public DateTime ProductQuatity { get; set; }

    public string ImageProduct { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;

    public virtual VoucherOfshop? Voucher { get; set; }
}
