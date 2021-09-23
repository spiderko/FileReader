using System;

namespace FileReader.Core.Models
{
    public class RainFallData : BaseClass
    {
        public RainFallData(int xref, int yref, DateTime date, int value)
        {
            Xref = xref;
            Yref = yref;
            Date = date;
            Value = value;
            Created = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        public int Xref { get; set; }
        public int Yref { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
