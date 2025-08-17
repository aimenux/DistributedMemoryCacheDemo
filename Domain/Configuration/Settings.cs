using System.Collections.Generic;

namespace Domain.Configuration;

public sealed record Settings
{
    public const string SectionName = "Settings";
    
    public ICollection<string> BlacklistUrls { get; init; }

    public CacheSettings CacheSettings { get; init; }
}