using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Ports;

namespace Infrastructure.DistributedCaches
{
    public class WebSiteCacheProvider : IWebSiteCacheProvider
    {
        private readonly IDistributedCacheProvider _distributedCacheProvider;

        public WebSiteCacheProvider(IDistributedCacheProvider distributedCacheProvider)
        {
            _distributedCacheProvider = distributedCacheProvider;
        }

        public Task<WebSite> GetWebSiteAsync(string url, CancellationToken cancellationToken = default)
        {
            return _distributedCacheProvider.GetAsync<WebSite>(url, cancellationToken);
        }

        public Task SetWebSiteAsync(WebSite website, CancellationToken cancellationToken = default)
        {
            return _distributedCacheProvider.SetAsync(website.Url, website, cancellationToken);
        }
    }
}
