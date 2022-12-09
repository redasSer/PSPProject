using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("CatalogueItem")]
    public class CatalogueItemModel
    {
        [Required]
        public Guid catalogueItemId { get; set; }
        public Guid clientId { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        
        [Required]
        public double price { get; set; }
        public int loyaltyPointsReward { get; set; }
        public int tax { get; set; }
        
    }
}