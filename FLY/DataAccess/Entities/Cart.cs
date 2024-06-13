using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class Cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CartId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public int CartQuantity { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }
}
