using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Configuration;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.Extensions.Options;

namespace Domain.Services;

public class DummyService : IDummyService
{
    private readonly IDummyClient _client;
    private readonly IDistributedCacheProvider _cache;
    private readonly IOptions<Settings> _options;

    public DummyService(IDummyClient client, IDistributedCacheProvider cache, IOptions<Settings> options)
    {
        _cache = cache;
        _client = client;
        _options = options;
    }

    public async Task<WebSite> GetWebSiteAsync(string url, CancellationToken cancellationToken = default)
    {
        if (IsBlackListedUrl(url))
        {
            throw BusinessValidationException.UrlIsBlackListed(url);
        }

        var website = await _cache.GetAsync<WebSite>(url, cancellationToken);
        if (website != null)
        {
            return website;
        }

        var length = await GetContentLengthAsync(url, cancellationToken);
        website = new WebSite
        {
            Url = url,
            Length = length
        };

        await _cache.SetAsync(website.Url, website, cancellationToken);
        return website;
    }

    private async Task<int> GetContentLengthAsync(string url, CancellationToken cancellationToken = default)
    {
        var content = await _client.GetContentAsync(url, cancellationToken);
        return content.Length;
    }

    private bool IsBlackListedUrl(string url)
    {
        var blacklistUrls = _options.Value.BlacklistUrls ?? Array.Empty<string>();
        return blacklistUrls.Contains(url, StringComparer.OrdinalIgnoreCase);
    }
}