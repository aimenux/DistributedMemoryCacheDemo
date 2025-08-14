using System.Threading;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IDummyClient
{
    Task<string> GetContentAsync(string url, CancellationToken cancellationToken = default);
}