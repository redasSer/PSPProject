using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("OrderedItemModification")]
    [PrimaryKey(nameof(OrderedItemId), nameof(ModifierId))]
    public class OrderedItemModification
    {
        public Guid OrderedItemId { get; set; }
        public Guid ModifierId { get; set; }
    }
}
