using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication1.Models;

public class Bid
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    public DateTime BidTime { get; set; } = DateTime.UtcNow;

    public int AuctionId { get; set; }
    [ForeignKey(nameof(AuctionId))]
    public Auction? Auction { get; set; }

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}
