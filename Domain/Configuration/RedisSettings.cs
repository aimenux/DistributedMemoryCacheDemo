namespace Domain.Configuration;

public sealed record RedisSettings
{
    public string ConnectionString { get; init; }
}