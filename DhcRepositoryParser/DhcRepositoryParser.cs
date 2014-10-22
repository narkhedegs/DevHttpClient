using System;
using DhcRepositoryParser.DataObjects;
using Newtonsoft.Json;

namespace DhcRepositoryParser
{
    public interface IDhcRepositoryParser
    {
        DhcRepository Parse(string dhcRepositoryJson);
    }

    public class DhcRepositoryParser : IDhcRepositoryParser
    {
        public DhcRepository Parse(string dhcRepositoryJson)
        {
            if(string.IsNullOrEmpty(dhcRepositoryJson)) throw new ArgumentNullException("dhcRepositoryJson");

            return JsonConvert.DeserializeObject<DhcRepository>(dhcRepositoryJson);
        }
    }
}
