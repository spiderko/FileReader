using System;

namespace FileReader.Core.Models
{
    public class RainFallData : BaseClass
    {
        public RainFallData(
            Guid headerId,
            int xref, 
            int yref, 
            DateTime date, 
            int day,
            int month,
            int year,
            int value)
        {
            HeaderId = headerId;
            Xref = xref;
            Yref = yref;
            Date = date;
            Day = day;
            Month = month;
            Year = year;
            Value = value;
            Created = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }
        public Guid? HeaderId { get; set; }
        public int Xref { get; set; }
        public int Yref { get; set; }
        public DateTime Date { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Value { get; set; }
    }
}
