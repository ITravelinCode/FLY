using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class Blog
{
    public int BlogId { get; set; }

    public int AccountId { get; set; }

    public string BlogName { get; set; } = null!;

    public DateOnly BlogDate { get; set; }

    public string BlogContent { get; set; } = null!;

    public string BlogImage { get; set; } = null!;

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;
}
