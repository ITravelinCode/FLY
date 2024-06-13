using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int ShopId { get; set; }

    [Required]
    [MaxLength(250)]
    public string Content { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; }
}
