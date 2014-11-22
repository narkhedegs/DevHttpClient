using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    internal class UrlConverter : JsonConverter
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
            var url = new Url();
            url.Scheme = jObject["scheme"] != null ? jObject["scheme"].Value<string>("name") : string.Empty;
            url.Path = jObject.Value<string>("path");
            if (jObject["query"] != null)
            {
                url.QueryDelimiter = jObject["query"].Value<string>("delimiter");
                foreach (var item in jObject["query"]["items"])
                {
                    var isEnabled = item.Value<bool?>("enabled");
                    var name = item.Value<string>("name");
                    var value = item.Value<string>("value");
                    if (isEnabled == null || isEnabled.Value)
                    {
                        url.QueryParameters.Add(name, value);
                    }
                }
            }

            return url;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (IUrl);
        }
    }
}
