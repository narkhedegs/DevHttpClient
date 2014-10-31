using System.Collections.Generic;
using DevHttpClient.JsonConverters;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace DevHttpClient.DataObjects
{
    public class RestRequest : IRestRequest
    {
        [JsonConverter(typeof(HeadersConverter))]
        public IDictionary<string, string> Headers { get; set; }

        [JsonConverter(typeof(MethodConverter))]
        public RestRequestMethod Method { get; set; }

        [JsonConverter(typeof(BodyConverter))]
        public string Body { get; set; }

        [JsonProperty("uri"),JsonConverter(typeof(UrlConverter))]
        public IUrl Url { get; set; }
    }
}
