using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("Inventory")]
public class Inventory
{
    [Required]
    [Key]
    public Guid ItemId { get; set; }
    public Guid LocationId { get; set; }
    internal virtual Location Location { get; set; }
    public string Item { get; set; }
    public int Amount { get; set; }
}