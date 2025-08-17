namespace Domain.Configuration;

public sealed record SqlServerSettings
{
    public string ConnectionString { get; init; }
    public string SchemaName { get; init; }
    public string TableName { get; init; }
}