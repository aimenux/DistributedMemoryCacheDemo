namespace Infrastructure.DistributedCaches;

public class DistributedCacheOptions
{
    public int ExpirationInMinutes { get; set; } = 2;
}