using System.Collections.Generic;

namespace DevHttpClient.DataObjects
{
    public class Query
    {
        public string Delimiter { get; set; }
        public List<QueryItem> Items { get; set; }
    }
}