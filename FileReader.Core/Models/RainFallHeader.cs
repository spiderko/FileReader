using System;

namespace FileReader.Core.Models
{
    public class RainFallHeader : BaseClass
    {
        public RainFallHeader(
            string title,
            string type,
            string climaticResearchUnitVersion,
            string createdBy,
            DateTime createdOn,
            decimal longitudeMin,
            decimal longitudeMax,
            decimal latitudeMin,
            decimal latitudeMax,
            int gridX,
            int gridY,
            int boxes,
            int yearMin,
            int yearMax,
            decimal multi,
            int missing)
        {
            Id = Guid.NewGuid();
            Title = title;
            Type = type;
            ClimaticResearchUnitVersion = climaticResearchUnitVersion;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            LongitudeMin = longitudeMin;
            LongitudeMax = longitudeMax;
            LatitudeMin = latitudeMin;
            LatitudeMax = latitudeMax;
            GridX = gridX;
            GridY = gridY;
            Boxes = boxes;
            YearMin = yearMin;
            YearMax = yearMax;
            Multi = multi;
            Missing = missing;
            Created = DateTime.UtcNow;
        }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ClimaticResearchUnitVersion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal LongitudeMin { get; set; }
        public decimal LongitudeMax { get; set; }
        public decimal LatitudeMin { get; set; }
        public decimal LatitudeMax { get; set; }
        public int GridX { get; set; }
        public int GridY { get; set; }
        public int Boxes { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public decimal Multi { get; set; }
        public int Missing { get; set; }
    }
}
