using System.Collections.Generic;

namespace DevHttpClient.DataObjects
{
    public class Repository
    {
        public int Version { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
