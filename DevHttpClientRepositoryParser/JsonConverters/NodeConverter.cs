using System;
using DevHttpClient.DataObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevHttpClient.JsonConverters
{
    public class NodeConverter : JsonConverter
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
                    string.Format("Unexpected JSON token when reading Node. Expected StartObject, got {0}.",
                        reader.TokenType));
            }

            var jObject = JObject.Load(reader);

            var node = new Node();
            serializer.Populate(jObject.CreateReader(), node);

            var restRequest = serializer.Deserialize<RestRequest>(jObject.CreateReader());

            node.Request = restRequest;

            return node;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Node);
        }
    }
}