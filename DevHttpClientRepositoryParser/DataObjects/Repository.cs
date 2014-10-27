using System.Collections.Generic;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace DevHttpClient.DataObjects
{
    public class Repository : IRestRequestCollection<Node>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("nodes")]
        public IEnumerable<Node> Items { get; set; }
    }
}
