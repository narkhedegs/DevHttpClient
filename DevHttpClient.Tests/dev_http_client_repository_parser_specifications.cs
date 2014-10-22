﻿using System;
using System.Linq;
using DevHttpClient.DataObjects;
using DevHttpClient.Tests.Helpers;
using NSpec;

namespace DevHttpClient.Tests
{
    class dev_http_client_repository_parser_specifications : nspec
    {
        private string _validDevHttpClientRepositoryJson;
        private IDevHttpClientRepositoryParser _devHttpClientRepositoryParser;

        void when_parsing_dev_http_client_repository_json()
        {
            before = () =>
            {
                _devHttpClientRepositoryParser = new DevHttpClientRepositoryParser();
                _validDevHttpClientRepositoryJson = EmbeddedResourceHelper.GetEmbeddedResource("Data/sample.json");
            };

            context["given null or empty devHttpClientRepositoryJson"] = () =>
            {
                it["should throw ArgumentNullException"] = expect<ArgumentNullException>(() => _devHttpClientRepositoryParser.Parse(null));
            };

            context["given a valid devHttpClientRepositoryJson"] = () =>
            {
                DevHttpClientRepository repository = null;

                act = () => repository = _devHttpClientRepositoryParser.Parse(_validDevHttpClientRepositoryJson);

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
