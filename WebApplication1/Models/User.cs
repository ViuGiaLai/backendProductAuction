using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WebApplication1.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    
    public string Role { get; set; } = "User"; // Admin, User
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
