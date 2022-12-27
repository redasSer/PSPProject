using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("OrderedItem")]
public class OrderedItem
{
    [Required]
    [Key]
    public Guid OrderedItemId { get; set; }
    public Guid LocationId { get; set; }
    internal virtual Location Location { get; set; }
    public Guid OrderId { get; set; }
    internal virtual Order Order { get; set; }
    public Guid CatalogueItemId { get; set; }
    internal virtual CatalogueItem CatalogueItem { get; set; }
    public string Comment { get; set; }
    public double Price { get; set; }
    public double Tax { get; set; }
    public int Amount { get; set; }
}