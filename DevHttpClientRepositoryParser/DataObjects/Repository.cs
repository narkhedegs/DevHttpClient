using System.Collections.Generic;
using DevHttpClient.JsonConverters;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace DevHttpClient.DataObjects
{
    public class Repository : IRestRequestCollection<IRestRequestCollectionItem>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("nodes"),JsonConverter(typeof(ConcreteTypeConverter<IEnumerable<Node>>))]
        public IEnumerable<IRestRequestCollectionItem> Items { get; set; }
    }
}
