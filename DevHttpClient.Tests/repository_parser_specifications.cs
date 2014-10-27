using System;
using System.Linq;
using DevHttpClient.Tests.Helpers;
using NSpec;
using RestApiTester.Common;

namespace DevHttpClient.Tests
{
    public class repository_parser_specifications : nspec
    {
        private string _validDevHttpClientRepositoryJson;
        private IRestRequestCollectionParser _repositoryParser;

        public void when_parsing_dev_http_client_repository_json()
        {
            before = () =>
            {
                _repositoryParser = new RepositoryParser();
                _validDevHttpClientRepositoryJson =
                    EmbeddedResourceHelper.GetEmbeddedResource("Data/sample-repository.json");
            };

            context["given null or empty devHttpClientRepositoryJson"] =
                () =>
                {
                    it["should throw ArgumentNullException"] =
                        expect<ArgumentNullException>(() => _repositoryParser.Parse(null));
                };

            context["given a valid devHttpClientRepositoryJson"] = () =>
            {
                IRestRequestCollection<IRestRequestCollectionItem> repository = null;
                IRestRequest request = null;

                act = () => 
                {
                    repository = _repositoryParser.Parse(_validDevHttpClientRepositoryJson);
                    request = repository.Items.ToList()[1].Request;
                };

                it["repository should not be null"] = () => repository.should_not_be_null();
                it["repository should have one node of type Project"] =
                    () => repository.Items.Where(node => node.Type == RestRequestCollectionItemType.Project).ToList().Count().should_be(1);
                it["repository should have five nodes of type Request"] =
                    () => repository.Items.Where(node => node.Type == RestRequestCollectionItemType.Request).ToList().Count().should_be(5);
                it["should populate Id"] = () => repository.Items.ToList()[1].Id.should_be("0BB1241E-BB85-49C8-9954-1CFEED3A3355");
                it["should populate ParentId"] = () => repository.Items.ToList()[1].ParentId.should_be("1B32D16A-8F50-4A3B-B82D-493549DCA656");
                it["should populate Name"] = () => repository.Items.ToList()[1].Name.should_be("Get Work List By Scheduler Key");
                it["should populate UpdatedDateTime"] = () => repository.Items.ToList()[1].UpdatedDateTime.should_be(DateTime.Parse("2014-06-11T11:14:29.521-04:00"));

                it["should populate Headers"] = () =>
                {
                    request.Headers["Token"].should_be("${Token}");
                    request.Headers["Content-Type"].should_be("application/json");
                };
                it["should populate Method"] = () => request.Method.should_be(RestRequestMethod.Get);
                it["should populate Body"] = () => request.Body.should_be("{\"_DiseaseRegistry\":\" \",\n \"_FirstName\":\"\",\n \"_Lastname\":\"\",\n \"_MemberId\":\"\",\n \"_NextApptDate\":null,\n \"_ProviderId\":0046,\n \"_staffkey\":666}");
                it["should populate Url"] = () => request.Url.should_be("http://${URI}/WorkListService/WorkLists/12361712");
            };
        }
    }
}
