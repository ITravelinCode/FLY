using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FLY.DataAccess.Entities;

public partial class Rating
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RateId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int ShopId { get; set; }

    [Required]
    public float RateNumber { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; }
}
