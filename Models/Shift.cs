using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PSP.Models;
[Table("Shift")]
public class Shift
{
    [JsonProperty("shiftId")]
    [Key]
    public Guid ShiftId { get; set; }

    [NotMapped]
    private TimeOnly startTime;


    [JsonConverter(typeof(TimeOnly))]
    [NotMapped]
    [Required]
    public TimeOnly StartTime
    {
        get
        {
            if (EndTimeTS == null) return null;
            if (this.startTime == null)
            {
                this.startTime = new TimeOnly();
                this.startTime.Hour = this.StartTimeTS.Hours;
                this.startTime.Minute = this.StartTimeTS.Minutes;
                this.startTime.Second = this.StartTimeTS.Seconds;
                this.startTime.Millisecond = this.StartTimeTS.Milliseconds;
                if(this.StartTime.Ticks >0) this.StartTime.Ticks = this.StartTimeTS.Ticks;
            }
            return this.startTime;
        }

        set
        {
            System.TimeOnly timeOnly;
            if (value.Ticks != 0) timeOnly = new System.TimeOnly(value.Ticks);
            else timeOnly = new System.TimeOnly(value.Hour, value.Minute, value.Second, value.Millisecond);
            StartTimeTS = timeOnly.ToTimeSpan();
            this.startTime = value;
        }
    }
    [NotMapped]
    private TimeOnly endTime;


    [JsonConverter(typeof(TimeOnly))]
    [NotMapped]
    [Required]

    public TimeOnly EndTime
    {
        get
        {
            if (EndTimeTS == null) return null;
            if (this.endTime == null)
            {
                this.endTime = new TimeOnly();
                this.endTime.Hour = this.EndTimeTS.Hours;
                this.endTime.Minute = this.EndTimeTS.Minutes;
                this.endTime.Second = this.EndTimeTS.Seconds;
                this.endTime.Millisecond = this.EndTimeTS.Milliseconds;
                if (this.StartTime.Ticks > 0) this.StartTime.Ticks = this.StartTimeTS.Ticks;
            }
            return this.endTime;
        }

        set
        {
            System.TimeOnly timeOnly;
            if ( value.Ticks != 0) timeOnly = new System.TimeOnly(value.Ticks);
            else timeOnly = new System.TimeOnly(value.Hour, value.Minute, value.Second, value.Millisecond);
            EndTimeTS = timeOnly.ToTimeSpan();
            this.endTime = value;
        }
    }

    [JsonIgnore]
    [Required]
    internal TimeSpan StartTimeTS { get; set; }
    [Required]
    [JsonIgnore]
    internal TimeSpan EndTimeTS { get; set; }

}

