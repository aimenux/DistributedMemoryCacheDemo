using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Ports
{
    public interface IWebSiteCacheProvider
    {
        Task<WebSite> GetWebSiteAsync(string url, CancellationToken cancellationToken = default);

        Task SetWebSiteAsync(WebSite website, CancellationToken cancellationToken = default);
    }
}