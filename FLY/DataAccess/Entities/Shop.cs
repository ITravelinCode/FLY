using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Shop
{
    public int ShopId { get; set; }

    public int AccountId { get; set; }

    public string ShopName { get; set; } = null!;

    public string ShopDetail { get; set; } = null!;

    public string ShopAddress { get; set; } = null!;

    public DateTime ShopStartTime { get; set; }

    public DateTime ShopEndTime { get; set; }

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
