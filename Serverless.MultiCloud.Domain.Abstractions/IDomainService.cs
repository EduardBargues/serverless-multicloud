using System.Threading.Tasks;

namespace Serverless.MultiCloud.Domain.Abstractions
{
    public interface IDomainService
    {
        Task<string> DoDomainActionAsync();
    }
}
