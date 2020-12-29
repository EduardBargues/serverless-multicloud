using System.Threading.Tasks;

namespace Serverless.MultiCloud.Repository.Abstractions
{
    public interface IRepository<T>
    {
        Task<string> SaveAsync(T item);
    }
}
