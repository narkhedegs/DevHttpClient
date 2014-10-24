using System;
using DevHttpClient.DataObjects;
using Newtonsoft.Json;

namespace DevHttpClient
{
    public interface IRepositoryParser
    {
        Repository Parse(string repositoryJson);
    }

    public class RepositoryParser : IRepositoryParser
    {
        public Repository Parse(string repositoryJson)
        {
            if (string.IsNullOrEmpty(repositoryJson)) throw new ArgumentNullException("repositoryJson");

            return JsonConvert.DeserializeObject<Repository>(repositoryJson);
        }
    }
}
