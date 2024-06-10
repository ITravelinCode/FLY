﻿using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    public DateTime OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
