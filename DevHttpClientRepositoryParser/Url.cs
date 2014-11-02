using System.Collections.Generic;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    internal class Url : IUrl
    {
        public Url()
        {
            QueryParameters = new Dictionary<string, string>();
        }

        public string Scheme { get; set; }
        public string Path { get; set; }
        public string QueryDelimiter { get; set; }
        public IDictionary<string, string> QueryParameters { get; set; }
    }
}
