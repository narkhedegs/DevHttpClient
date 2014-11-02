using System;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace RestApiTester.Parsers
{
    public class DevHttpClientRepositoryParser : IRestRequestCollectionParser
    {
        public IRestRequestCollection Parse(string repositoryJson)
        {
            if (string.IsNullOrEmpty(repositoryJson)) throw new ArgumentNullException("repositoryJson");

            return JsonConvert.DeserializeObject<Repository>(repositoryJson);
        }
    }
}
