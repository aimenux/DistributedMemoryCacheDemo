using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Abstractions;

public interface IDummyService
{
    Task<WebSite> GetWebSiteAsync(string url, CancellationToken cancellationToken = default);
}