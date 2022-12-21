using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PSP.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [JsonProperty("roleId")]
        public Guid RoleId { get; set; }

        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }
        internal virtual Client client { get; set; }


        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
