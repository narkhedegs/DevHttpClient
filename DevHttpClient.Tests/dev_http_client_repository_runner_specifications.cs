using System;
using System.Collections.Generic;
using DevHttpClient.DataObjects;
using Moq;
using NSpec;
using Uri = DevHttpClient.DataObjects.Uri;

namespace DevHttpClient.Tests
{
    class dev_http_client_repository_runner_specifications : nspec
    {
        private Mock<IRepositoryParser> _devHttpClientRepositoryParser;
        private IRepositoryRunner _repositoryRunner;

        void when_running_dev_http_client_repository()
        {
            before = () =>
            {
                _devHttpClientRepositoryParser = new Mock<IRepositoryParser>();
                _devHttpClientRepositoryParser.Setup(parser => parser.Parse(It.IsAny<string>()))
                    .Returns(DevHttpClientRepositoryGenerator.Default);

                _repositoryRunner = new RepositoryRunner(_devHttpClientRepositoryParser.Object);
            };

            act = () => 

            it["should use DevHttpClientRepositoryParser to parse repository json"] = () =>
            {
                
            };
        }
    }

    public static class DevHttpClientRepositoryGenerator
    {
        public static Repository Default()
        {
           return new Repository
           {
               Version = 3
           };
        }
    }

    public static class DevHttpClientRepositoryNodeGenerator
    {
        public static Node Default()
        {
            return new Node
            {
                Id = Guid.NewGuid().ToString(),
                ParentId = Guid.NewGuid().ToString(),
                LastModifiedDateTime = DateTime.Now,
                Name = "Get Sample",
                Method = "GET",
                Type = NodeType.Request,
                Body = DevHttpClientRequestBodyGenerator.Default(),
                Headers = new List<Header>
                {
                    DevHttpClientRequestHeaderGenerator.Default()
                },
                Uri = DevHttpClientRequestUriGenerator.Default()
            };
        }

        public static Node WithParentId(this Node node, string parentId)
        {
            node.ParentId = parentId;
            return node;
        }

        public static Node WithName(this Node node, string name)
        {
            node.Name = name;
            return node;
        }

        public static Node WithMethod(this Node node, string method)
        {
            node.Method = method;
            return node;
        }

        public static Node WithType(this Node node, NodeType type)
        {
            node.Type = type;
            return node;
        }
    }

    public static class DevHttpClientRequestBodyGenerator
    {
        public static Body Default()
        {
            return new Body
            {
                BodyType = BodyType.Text,
                TextBody = "{\n\"ActionType\":null,\n\"ActionTypeKey\":1232,\n\"AlterBy\":null,\n\"AlterByKey\":null,\n\"AlterDate\":null,\n\"CompletedDateTime\":null,\n\"CreatedBy\":null,\n\"CreatedByKey\":null,\n\"CreatedDate\":null,\n\"DueDateTime\":\"\\/Date(1239595200000-0400)\\/\",\n\"EnrolleeKey\":12312131,\n\"Medication\":null,\n\"MedicationKey\":null,\n\"MemberName\":\"Doe, John\",\n\"PrimaryStaffKey\":21736,\n\"PrimaryStaffName\":null,\n\"Priority\":null,\n\"PriorityKey\":1,\n\"ReferralKey\":null,\n\"ReferralReason\":null,\n\"SchedulerId\":null,\n\"SchedulerKey\":null,\n\"Status\":null,\n\"StatusKey\":1,\n\"Age\":\"7 Years\",\n\"AssessmentKey\":null,\n\"AssignedBy\":null,\n\"AssignedByKey\":1231,\n\"CarePlanId\":null,\n\"CareProgram\":null,\n\"CareProgramKey\":null,\n\"CaseKey\":null,\n\"CloseReason\":null,\n\"CloseReasonKey\":null,\n\"Comment\":null,\n\"ConditionCenterKey\":null,\n\"County\":\"BEAVER\",\n\"DateOfBirth\":\"\\/Date(1175054400000-0400)\\/\",\n\"EndDate\":null,\n\"Formulary\":\"\",\n\"FormularyKey\":null,\n\"GroupName\":\"Microsoft Inc\",\n\"LengthOfStay\":0,\n\"LineOfBusiness\":\"Test\",\n\"LockedByStaffKey\":null,\n\"LockedByStaffName\":null,\n\"MemberIdCaseId\":\"12736176327163\",\n\"MessageSender\":\"Doe Jane\",\n\"Provider\":\"Test MD\",\n\"ProviderKey\":2347287,\n\"ReceivedDateTime\":null,\n\"ReferredBy\":null,\n\"ReferredByKey\":null,\n\"ReplyBy\":null,\n\"ReplyByKey\":null,\n\"SentDateTime\":null,\n\"SentTypeKey\":0,\n\"Source\":null,\n\"SourceKey\":4,\n\"StartDate\":null,\n\"WorkListType\":\"Test\",\n\"ZipCode\":\"2341243\"\n}"
            };
        }
    }

    public static class DevHttpClientRequestHeaderGenerator
    {
        public static Header Default()
        {
            return new Header
            {
                IsEnabled = true,
                Name = "SampleHeader",
                Value = "SampleHeaderValue"
            };
        }
    }

    public static class DevHttpClientRequestUriGenerator
    {
        public static Uri Default()
        {
            return new Uri
            {
                Path = "http://api.sample.com/users",
                Scheme = new Scheme {Name = "http"},
                Query = new Query
                {
                    Delimiter = "&",
                    Items = new List<QueryItem>
                    {
                        new QueryItem
                        {
                            IsEnabled = true,
                            Name = "SampleQueryItem",
                            Value = "SampleQueryItemValue"
                        }
                    }
                }
            };
        }
    }
}
