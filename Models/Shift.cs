using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSP.Models;

public class Shift
{
    [JsonProperty("shiftId")]
    [Key]
    public Guid ShiftId { get; set; }
    [JsonConverter(typeof(TimeOnly))]
    public TimeOnly StartTime { get; set; }

    [JsonConverter(typeof(TimeOnly))]
    public TimeOnly EndTime { get; set; }
}
