using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("CollectedLoyaltyReward")]
    public class CollectedLoyaltyReward
    {
        public Guid orderId { get; set; }
        public Guid loyaltyRewardId { get; set; }
    }
}