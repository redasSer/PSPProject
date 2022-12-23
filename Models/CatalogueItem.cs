using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("CatalogueItem")]
public class CatalogueItem
{
    [Required]
    [Key]
    public Guid CatalogueItemId { get; set; }
    public Guid ClientId { get; set; }
    internal virtual Client Client { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int LoyaltyPointsReward { get; set; }
    public int Tax { get; set; }
    
}