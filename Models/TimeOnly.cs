using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PSP.Models
{
    [Keyless]
    public class TimeOnly
    {

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }

        [JsonProperty("second")]
        public int Second { get; set; }

        [JsonProperty("millisecond")]
        public int Millisecond { get; set; }

        [JsonProperty("ticks")]
        public long Ticks { get; set; }

    }
}
