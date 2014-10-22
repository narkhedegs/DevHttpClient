using System.Collections.Generic;

namespace DhcRepositoryParser.DataObjects
{
    public class DhcRepository
    {
        public int Version { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
