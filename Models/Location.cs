using Newtonsoft.Json;
using System;

namespace PSP.Models
{
    public class Location
    {
        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }

        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("tax")]
        public double Tax { get; set; }
    }
}
