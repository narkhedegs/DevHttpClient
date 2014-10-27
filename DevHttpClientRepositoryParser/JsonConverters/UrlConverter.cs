using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevHttpClient.JsonConverters
{
    public class UrlConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new JsonSerializationException(
                    string.Format("Unexpected JSON token when reading Url. Expected StartObject, got {0}.",
                        reader.TokenType));
            }

            var jObject = JObject.Load(reader);
            var scheme = jObject["scheme"].Value<string>("name");
            var path = jObject.Value<string>("path");
            var queryDelimiter = jObject["query"].Value<string>("delimiter");
            var queryParameters = (from item in jObject["query"]["items"]
                let isEnabled = item.Value<bool?>("enabled")
                let name = item.Value<string>("name")
                let value = item.Value<string>("value")
                where isEnabled == null || isEnabled.Value
                select new {Name = name, Value = value}).ToList();
            var url = string.Format(@"{0}://{1}", scheme, path);

            for (var i = 0; i < queryParameters.Count(); i++)
            {
                var queryParameter = queryParameters[i];
                url += "?" + queryParameter.Name + "=" + queryParameter.Value;
                if (i != queryParameters.Count - 1)
                {
                    url += queryDelimiter;
                }
            }

            return url;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (string);
        }
    }
}
