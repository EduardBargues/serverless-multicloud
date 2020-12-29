using System;
using System.Threading.Tasks;

using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serverless.MultiCloud.Domain;
using Serverless.MultiCloud.Domain.Abstractions;
using Serverless.MultiCloud.Repository.Abstractions;
using Serverless.MultiCloud.Repository.Aws;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
        private readonly IDomainService _domainService;

        public Handler()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddLogging();
            services.AddTransient<IDomainService, DomainService>();
            services.AddTransient<IRepository<DomainEntity>, AwsRepository>();

            var configuration = new ConfigurationBuilder().Build();
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();

            var messagesTableName = Environment.GetEnvironmentVariable("MESSAGES_TABLE");
            services.Configure<AwsRepositoryConfiguration>(conf => conf.MessagesTableName = messagesTableName);

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            _domainService = serviceProvider.GetService<IDomainService>();
        }

        public async Task<Response> Hello(Request request)
        {
            var result = await _domainService.DoDomainActionAsync();
            return new Response(result, request);
        }
    }
}
