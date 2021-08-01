using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DistributedCaches
{
    public interface IDistributedCacheProvider
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;

        Task SetAsync<T>(string key, T obj, CancellationToken cancellationToken = default) where T : class;
    }
}