using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public string ImageProduct { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
