using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class RefreshToken
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RefreshTokenId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public string Token { get; set; }

    [Required]
    [MaxLength(150)]
    public string DeviceName { get; set; }

    [Required]
    public DateTime ExpiredDate { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }
}
