using System;
using System.ComponentModel.DataAnnotations.Schema;
using PSP.Enums;

namespace PSP.Models;

[Table("LoyaltyCard")]
public class LoyaltyCard
{
    public Guid cardId { get; set; }
    public Guid customerId { get; set; }
    public Guid clientId { get; set; }
    public int loyaltyPoints { get; set; }
    public CardStatus status { get; set; }
}