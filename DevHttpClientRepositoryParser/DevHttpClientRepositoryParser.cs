using System;
using DevHttpClient.DataObjects;
using Newtonsoft.Json;

namespace DevHttpClient
{
    public interface IDevHttpClientRepositoryParser
    {
        DevHttpClientRepository Parse(string devHttpClientRepositoryJson);
    }

    public class DevHttpClientRepositoryParser : IDevHttpClientRepositoryParser
    {
        public DevHttpClientRepository Parse(string devHttpClientRepositoryJson)
        {
            if (string.IsNullOrEmpty(devHttpClientRepositoryJson)) throw new ArgumentNullException("devHttpClientRepositoryJson");

            return JsonConvert.DeserializeObject<DevHttpClientRepository>(devHttpClientRepositoryJson);
        }
    }
}
