using Microsoft.EntityFrameworkCore;
using PSP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("LoyaltyRewards")]
    [PrimaryKey(nameof(LoyaltyRewardId))]
    public class LoyaltyRewards
    {
        public Guid LoyaltyRewardId { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public Guid CatalogueItemId { get; set; }
        public int LoyaltyPointsCost { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public LoyaltyRewardsStatus Status { get; set; }
    }
}
