
using Microsoft.Extensions.DependencyInjection;

using Serverless.MultiCloud.Domain.Abstractions;

namespace Serverless.MultiCloud.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IDomainService, DomainService>();

            return services;
        }
    }
}
