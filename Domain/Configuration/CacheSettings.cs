namespace Domain.Configuration;

public sealed record CacheSettings
{
    public int ExpirationInMinutes { get; init; } = 2;
    public string Source { get; init; } = nameof(CacheSource.Memory);
    public RedisSettings Redis { get; init; }
    
    public SqlServerSettings SqlServer { get; init; }
}