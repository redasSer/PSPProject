using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("SubscriptionsType")]
    public class SubscriptionsType
    {
        [Key]
        public Guid SubscriptionTypeId { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public int QueryLimit { get; set; }
        public double Price { get; set; }
    }
}
