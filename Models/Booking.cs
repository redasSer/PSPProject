using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("Booking")]
public class Booking
{
    [Required]
    [Key]
    public Guid bookingId { get; set; }
    
    [Required]
    public Guid orderId { get; set; }
    
    [Required]
    public DateTime time { get; set; }
    
    public string description { get; set; }
}