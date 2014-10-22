using Newtonsoft.Json;

namespace DevHttpClient.DataObjects
{
    public class Header
    {
        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}