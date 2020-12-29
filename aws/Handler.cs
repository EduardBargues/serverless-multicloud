using System.Threading.Tasks;

using Amazon.Lambda.Core;

using Microsoft.Extensions.DependencyInjection;

using Serverless.MultiCloud.Domain;
using Serverless.MultiCloud.Domain.Abstractions;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
        private readonly IDomainService _domainService;

        public Handler()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _domainService = serviceProvider.GetService<IDomainService>();
        }

        public async Task<Response> Hello(Request request)
        {
            var result = await _domainService.DoDomainActionAsync();
            return new Response(result, request);
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureDomainServices();
        }
    }
}
