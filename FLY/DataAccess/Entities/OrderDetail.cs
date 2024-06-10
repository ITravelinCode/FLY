﻿using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int OrderQuantity { get; set; }

    public double ProductPrice { get; set; }

    public int Status { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}