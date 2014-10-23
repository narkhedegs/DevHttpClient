using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DevHttpClient.DataObjects
{
    public class Node
    {
        public string Id { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModifiedDateTime { get; set; }
        
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public NodeType Type { get; set; }

        public List<Header> Headers { get; set; }

        [JsonConverter(typeof(MethodConverter))]
        public string Method { get; set; }

        public Body Body { get; set; }
        public Uri Uri { get; set; }
        public string ParentId { get; set; }
    }
}