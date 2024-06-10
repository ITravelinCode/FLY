using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int AccountId { get; set; }

    public int CartQuantity { get; set; }

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
