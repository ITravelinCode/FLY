using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class ProductCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductCategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProductCategoryName { get; set; }

    [Required]
    [MaxLength(250)]
    public string ImageProduct { get; set; }

    [Required]
    public int Status { get; set; }

    public ICollection<Product> Products { get; set; }
}
