using System;
using System.Collections.Generic;

namespace FitbitHeartRateImporter.Models
{
    internal class ActivitiesHeart
    {
        public IEnumerable<CustomHeartRateZone> CustomHeartRateZones { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<HeartRateZone> HeartRateZones { get; set; }
        public double Value { get; set; }
    }
}
