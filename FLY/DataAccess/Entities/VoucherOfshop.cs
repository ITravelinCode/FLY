using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class VoucherOfshop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VoucherId { get; set; }

    [Required]
    [MaxLength(50)]
    public string VoucherName { get; set; }

    [Required]
    public float VoucherValue { get; set; }

    [Required]
    public DateTime VoucherStart { get; set; }

    [Required]
    public DateTime VoucherEnd { get; set; }

    [Required]
    public int Status { get; set; }

    public ICollection<Product> Products { get; set; }
}
