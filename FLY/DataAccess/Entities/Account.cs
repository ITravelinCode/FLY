using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FLY.DataAccess.Entities;

public partial class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }

    [MaxLength(10)]
    public string? Phone { get; set; }

    [MaxLength(12)]
    public int CitizenIdentification { get; set; }

    [MaxLength(10)]
    public int TaxCode { get; set; }

    [MaxLength(50)]
    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public int Status { get; set; }

    public ICollection<Shop>? Shops { get; set; }
    public ICollection<Blog>? Blogs { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; }
    public ICollection<Rating>? Ratings { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    public ICollection<Cart>? Carts { get; set; }
}
