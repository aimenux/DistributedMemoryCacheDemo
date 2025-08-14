using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.HttpClients;

public class DummyMessageHandler : DelegatingHandler
{
    private readonly ILogger<DummyMessageHandler> _logger;

    public DummyMessageHandler(ILogger<DummyMessageHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error has occurred on call to {url}", request.RequestUri);
            throw;
        }
    }
}