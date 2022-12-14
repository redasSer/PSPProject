using Newtonsoft.Json;
using PSP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PSP.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [JsonProperty("employeeId")]
        public Guid EmployeeId { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("roleId")]
        public Guid RoleId { get; set; }

        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("status")]
        public EmployeeStatus Status { get; set; }
    }
}
