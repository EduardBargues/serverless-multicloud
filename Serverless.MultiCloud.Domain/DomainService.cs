using System.Threading.Tasks;

using Serverless.MultiCloud.Domain.Abstractions;

namespace Serverless.MultiCloud.Domain
{
    public class DomainService : IDomainService
    {
        public Task<string> DoDomainActionAsync() => Task.FromResult("Domain logic executed :) !!");
    }
}
