using Microsoft.EntityFrameworkCore;
using System;

namespace PSP.Models
{
    public class DateOnly
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; } 
        public DayOfWeek dayOfWeek { get; set; }
        public int dayOfYear { get; set; }
        public int dayNumber { get; set; } // same as day ?!

        public static DateOnly Convert(DateTime date)
        {
            DateOnly dateOnly = new DateOnly();

            dateOnly.year = date.Year;
            dateOnly.month = date.Month;
            dateOnly.day = date.Day;

            dateOnly.dayOfWeek = date.DayOfWeek;
            dateOnly.dayOfYear = date.DayOfYear;
            dateOnly.dayNumber = date.Day;
            return dateOnly;
        }

        public DateTime Convert()
        {
           return  new DateTime(this.year, this.month, this.day);
        }
    }
}