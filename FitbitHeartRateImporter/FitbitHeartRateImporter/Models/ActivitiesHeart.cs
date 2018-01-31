using System;
using System.Collections.Generic;

namespace FitbitHeartRateImporter.Models
{
    internal class ActivitiesHeart
    {
        public DateTime DateTime { get; set; }
        public List<HeartRateZone> HeartRateZones { get; set; }
        public List<HeartRateZone> CustomHeartRateZones { get; set; }
        public int RestingHeartRate { get; set; }

        //    public IEnumerable<CustomHeartRateZone> CustomHeartRateZones { get; set; }
        //    public DateTime DateTime { get; set; }
        //    public IEnumerable<HeartRateZone> HeartRateZones { get; set; }
        //    public double Value { get; set; }
    }
}
