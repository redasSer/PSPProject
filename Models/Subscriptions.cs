using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("Subscriptions")]
    [PrimaryKey(nameof(ClientId), nameof(SubscriptionTypeId))]
    public class Subscriptions
    {
        public Guid ClientId { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
