using System;
using Domain.Abstractions;
using Domain.Configuration;
using Domain.Services;
using Infrastructure.DistributedCaches;
using Infrastructure.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

public partial class Startup
{
    private void ConfigureIoc(IServiceCollection services)
    {
        services.AddScoped<DummyMessageHandler>();

        services.AddScoped<IDummyService, DummyService>();

        services
            .AddHttpClient<IDummyClient, DummyClient>()
            .AddHttpMessageHandler<DummyMessageHandler>();

        services.Configure<Settings>(Configuration.GetSection(Settings.SectionName));
        
        services.AddSingleton<IDistributedCacheProvider, DistributedCacheProvider>();
        
        var settings = Configuration
            .GetSection(Settings.SectionName)
            .Get<Settings>();

        switch (settings.CacheSettings.Source)
        {
            case nameof(CacheSource.Memory):
                services.AddDistributedMemoryCache();
                break;
            case nameof(CacheSource.Redis):
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = settings.CacheSettings.Redis.ConnectionString;
                });
                break;
            case nameof(CacheSource.SqlServer):
                services.AddDistributedSqlServerCache(options =>
                {
                    options.ConnectionString = settings.CacheSettings.SqlServer.ConnectionString;
                    options.SchemaName = settings.CacheSettings.SqlServer.SchemaName;
                    options.TableName = settings.CacheSettings.SqlServer.TableName;
                });
                break;
            default:
                throw new NotSupportedException($"Distributed cache source '{settings.CacheSettings.Source}' is not supported.");
        }
    }
}