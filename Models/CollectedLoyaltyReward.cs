using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

[Table("CollectedLoyaltyReward")]
[PrimaryKey(nameof(orderId), nameof(loyaltyRewardId))]
public class CollectedLoyaltyReward
{
    public Guid orderId { get; set; }
    public Guid loyaltyRewardId { get; set; }
}