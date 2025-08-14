using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Infrastructure.HttpClients;

public class DummyClient : IDummyClient
{
    private readonly HttpClient _client;

    public DummyClient(HttpClient client)
    {
        _client = client;
    }

    public Task<string> GetContentAsync(string url, CancellationToken cancellationToken = default)
    {
        return _client.GetStringAsync(url, cancellationToken);
    }
}