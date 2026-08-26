using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplication1.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }
    
    public string PaymentMethod { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    
    public string Status { get; set; } = "Completed"; 

    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }
}
