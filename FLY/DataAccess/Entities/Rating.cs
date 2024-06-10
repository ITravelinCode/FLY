using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Rating
{
    public int RateId { get; set; }

    public int AccountId { get; set; }

    public int ShopId { get; set; }

    public double RateNumber { get; set; }

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
