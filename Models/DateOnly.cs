using System;

namespace PSP.Models
{
    public class DateOnly
    {
        public int year { get; set; }
        public int month { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public int dayOfYear { get; set; }
        public int dayNumber { get; set; }
    }
}