using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class VoucherOfshop
{
    public int VoucherId { get; set; }

    public string VoucherName { get; set; } = null!;

    public double VoucherValue { get; set; }

    public DateTime VoucherStart { get; set; }

    public DateTime VoucherEnd { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
