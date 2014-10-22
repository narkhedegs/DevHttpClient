using System;
using System.Linq;
using DhcRepositoryParser.DataObjects;
using DhcRepositoryParser.Tests.Helpers;
using NSpec;

namespace DhcRepositoryParser.Tests
{
    class dhc_repository_parser_specifications : nspec
    {
        private string _validDhcRepositoryJson;
        private IDhcRepositoryParser _dhcRepositoryParser;

        void when_parsing_dhc_repository_json()
        {
            before = () =>
            {
                _dhcRepositoryParser = new DhcRepositoryParser();
                _validDhcRepositoryJson = EmbeddedResourceHelper.GetEmbeddedResource("Data/sample.json");
            };

            context["given null or empty dhcRepositoryJson"] = () =>
            {
                it["should throw ArgumentNullException"] = expect<ArgumentNullException>(() => _dhcRepositoryParser.Parse(null));
            };

            context["given a valid dhcRepositoryJson"] = () =>
            {
                DhcRepository repository = null;

                act = () => repository = _dhcRepositoryParser.Parse(_validDhcRepositoryJson);

                it["repository should not be null"] = () => repository.should_not_be_null();
                it["repository should have a version"] = () => repository.Version.should_be(3);
                it["repository should have one node of type Project"] =
                    () => repository.Nodes.Where(node => node.Type == "Project").ToList().Count().should_be(1);
                it["repository should have five nodes of type Request"] =
                    () => repository.Nodes.Where(node => node.Type == "Request").ToList().Count().should_be(5);
            };
        }
    }
}
