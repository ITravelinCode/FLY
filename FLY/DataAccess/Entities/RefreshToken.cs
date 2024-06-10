using System;
using System.Collections.Generic;

namespace FLY.DataAccess.Entities;

public partial class RefreshToken
{
    public int RefreshTokenId { get; set; }

    public int AccountId { get; set; }

    public string Token { get; set; } = null!;

    public string DeviceName { get; set; } = null!;

    public DateTime ExpiredDate { get; set; }

    public int Status { get; set; }

    public virtual Account Account { get; set; } = null!;
}
