using System.Collections.Generic;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    internal class Repository : IRestRequestCollection
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("nodes"),JsonConverter(typeof(ConcreteTypeConverter<IEnumerable<Node>>))]
        public IEnumerable<IRestRequestCollectionItem> Items { get; set; }
    }
}
