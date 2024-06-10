using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class AccountShop
{
    public int AccountShopId { get; set; }

    public int AccountId { get; set; }

    public int ShopId { get; set; }

    public bool Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
