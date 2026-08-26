using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace WebApplication1.Models;

public class Auction
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal StartingPrice { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? CurrentHighestBid { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public string Status { get; set; } = "Pending"; // Pending, Active, Completed, Cancelled

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }

    public int? WinnerId { get; set; }
    [ForeignKey(nameof(WinnerId))]
    public User? Winner { get; set; }

    public ICollection<Bid> Bids { get; set; } = new List<Bid>();
}
