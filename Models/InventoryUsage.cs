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
    internal virtual CatalogueItem CatalogueItem { get; set; }
    public Guid ClientId { get; set; }
    internal virtual Client Client { get; set; }
    public Guid ItemId { get; set; }
    internal virtual Inventory Item { get; set; }
    public int Amount { get; set; }
    
}