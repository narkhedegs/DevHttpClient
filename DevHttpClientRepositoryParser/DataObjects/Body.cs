using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevHttpClient.DataObjects
{
    public class Body
    {
        public string TextBody { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BodyType BodyType { get; set; }
    }
}