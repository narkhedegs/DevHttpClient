using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevHttpClient.JsonConverters
{
    public class HeadersConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw new JsonSerializationException(
                    string.Format("Unexpected JSON token when reading Headers. Expected StartArray, got {0}.",
                        reader.TokenType));
            }

            var jArray = JArray.Load(reader);
            var headers = new Dictionary<string, string>();
            foreach (var jToken in jArray)
            {
                var isEnabled = jToken.Value<bool?>("enabled");
                var name = jToken.Value<string>("name");
                var value = jToken.Value<string>("value");

                if (isEnabled == null || isEnabled.Value)
                {
                    if (!headers.ContainsKey(name))
                    {
                        headers.Add(name, value);
                    }
                }
            }

            return headers;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (IEnumerable<KeyValuePair<string, string>>);
        }
    }
}