using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models
{
    [Table("Permission")]

    public class Permission
    {
        [Key]
        [JsonProperty("permissionId")]
        public Guid PermissionId { get; set; }

        [JsonProperty("roleId")]
        public Guid RoleId { get; set; }
        internal virtual Role role { get; set; }

        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }
        internal virtual Client client { get; set; }

        [JsonProperty("permissionTypeId")]
        public Guid PermissionTypeId { get; set; }
        internal virtual PermissionType permissionType { get; set; }
    }
}
