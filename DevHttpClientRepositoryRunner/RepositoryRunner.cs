namespace DevHttpClient
{
    public interface IRepositoryRunner
    {
        object Run(string devHttpClientRepositoryJson);
    }

    public class RepositoryRunner : IRepositoryRunner
    {
        private readonly IRepositoryParser _repositoryParser;

        public RepositoryRunner(IRepositoryParser repositoryParser)
        {
            _repositoryParser = repositoryParser;
        }

        public object Run(string devHttpClientRepositoryJson)
        {
            var devHttpClientRepository = _repositoryParser.Parse(devHttpClientRepositoryJson);

            return "hello";
        }
    }
}
