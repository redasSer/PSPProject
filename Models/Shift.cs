using Newtonsoft.Json;
using System;


namespace PSP.Models;

public class Shift
{
    [JsonProperty("shiftId")]
    public Guid ShiftId { get; set; }

    [JsonProperty("startTime")]
    public TimeOnly StartTime { get; set; }

    [JsonProperty("endTime")]
    public TimeOnly EndTime { get; set; }
}
