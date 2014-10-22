using System.Collections.Generic;

namespace DevHttpClient.DataObjects
{
    public class DevHttpClientRepository
    {
        public int Version { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
