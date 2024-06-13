using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlogId { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    [MaxLength(50)]
    public string BlogName { get; set; }

    [Required]
    public DateTime BlogDate { get; set; }

    [Required]
    [MaxLength(350)]
    public string BlogContent { get; set; }

    [Required]
    [MaxLength(250)]
    public string BlogImage { get; set; }

    [Required]
    public int Status { get; set; }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }
}
