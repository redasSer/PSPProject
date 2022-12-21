using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("Modifier")]
public class Modifier
{
    [Required]
    public Guid ModifierId { get; set; }
    public Guid CatalogueItemId { get; set; }
    public Guid ClientId { get; set; }
    public Guid ItemId { get; set; }
    public int Amount { get; set; }
    public int PriceModifier { get; set; }
    public int LoyaltyPointsModifier { get; set; }

}