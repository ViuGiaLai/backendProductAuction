using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication1.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    public string Status { get; set; } = "Pending"; // Pending, Paid, Shipped, Completed

    public int AuctionId { get; set; }
    [ForeignKey(nameof(AuctionId))]
    public Auction? Auction { get; set; }

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public Payment? Payment { get; set; }
}
