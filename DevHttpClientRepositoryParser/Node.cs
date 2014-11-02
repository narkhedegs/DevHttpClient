using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    [JsonConverter(typeof(NodeConverter))]
    internal class Node : IRestRequestCollectionItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RestRequestCollectionItemType Type { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? UpdatedDateTime { get; set; }

        public IRestRequest Request { get; set; }
    }
}