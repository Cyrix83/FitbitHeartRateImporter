using Newtonsoft.Json;

namespace FitbitHeartRateImporter.Models
{
    internal class FitbitModel
    {
        [JsonProperty(PropertyName = "activities-heart")]
        public ActivitiesHeart ActivitiesHeart { get; set; }

        [JsonProperty(PropertyName = "activities-heart-intraday")]
        public ActivitiesHeartIntraday ActivitiesHeartIntraday { get; set; }
    }
}
