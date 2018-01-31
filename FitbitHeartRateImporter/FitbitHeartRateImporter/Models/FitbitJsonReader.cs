using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitbitHeartRateImporter.Models
{
    internal class FitbitJsonReader : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var properties = jsonObject.Properties().ToList();

            //var result = new ActivitiesHeartIntraday
            //{
            //    DatasetInterval = Convert.ToInt32(jsonObject["DatasetInterval"]),
            //    DatasetType = jsonObject["DatasetType"].ToString(),
            //    Dataset = new List<DataSetInterval>()
            //};

            //foreach (JToken item in jsonObject["Dataset"].Children())
            //{
            //    result.Dataset.Add(new DataSetInterval()
            //    {
            //        Time = DateTime.Parse(item["Time"].ToString()),
            //        Value = Convert.ToInt32(item["Value"])
            //    });
            //};

            return "";
            //return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ActivitiesHeartIntraday).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
