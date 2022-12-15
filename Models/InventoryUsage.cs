using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("InventoryUsage")]
public class InventoryUsage
{
    [Required]
    [Key]
    public Guid InventoryUsageId { get; set; }
    public Guid CatalogueItemId { get; set; }
    public Guid ClientId { get; set; }
    public Guid ItemId { get; set; }
    public int Amount { get; set; }
    
}