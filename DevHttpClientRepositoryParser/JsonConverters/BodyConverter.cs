using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevHttpClient.JsonConverters
{
    public class BodyConverter : JsonConverter
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
                    string.Format("Unexpected JSON token when reading Body. Expected StartObject, got {0}.",
                        reader.TokenType));
            }

            var jObject = JObject.Load(reader);
            var bodyText = jObject.Value<string>("textBody");

            return bodyText;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (string);
        }
    }
}
