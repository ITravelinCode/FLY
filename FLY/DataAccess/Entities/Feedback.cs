using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int AccountId { get; set; }

    public int ShopId { get; set; }

    public string Content { get; set; } = null!;

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
