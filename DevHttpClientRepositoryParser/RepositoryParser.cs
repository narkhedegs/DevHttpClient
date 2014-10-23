using System;
using DevHttpClient.DataObjects;
using Newtonsoft.Json;

namespace DevHttpClient
{
    public interface IRepositoryParser
    {
        Repository Parse(string devHttpClientRepositoryJson);
    }

    public class RepositoryParser : IRepositoryParser
    {
        public Repository Parse(string devHttpClientRepositoryJson)
        {
            if (string.IsNullOrEmpty(devHttpClientRepositoryJson)) throw new ArgumentNullException("devHttpClientRepositoryJson");

            return JsonConvert.DeserializeObject<Repository>(devHttpClientRepositoryJson);
        }
    }
}
