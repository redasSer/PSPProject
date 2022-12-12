using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("PermissionType")]
    public class PermissionType
    {
        [Key]
        [JsonProperty("permissionTypeId")]
        public Guid PermissionTypeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
