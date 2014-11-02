using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    internal class MethodConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Enum.Parse(typeof (RestRequestMethod), Convert.ToString(JToken.Load(reader)["name"]),true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RestRequestMethod);
        }
    }
}