using System;
using DevHttpClient.DataObjects;
using Newtonsoft.Json;
using RestApiTester.Common;

namespace DevHttpClient
{
    public class RepositoryParser : IRestRequestCollectionParser
    {
        public IRestRequestCollection Parse(string repositoryJson)
        {
            if (string.IsNullOrEmpty(repositoryJson)) throw new ArgumentNullException("repositoryJson");

            return JsonConvert.DeserializeObject<Repository>(repositoryJson);
        }
    }
}
