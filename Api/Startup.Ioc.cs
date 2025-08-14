using Domain.Abstractions;
using Domain.Configuration;
using Domain.Services;
using Infrastructure.DistributedCaches;
using Infrastructure.HttpClients;
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

        services.AddDistributedMemoryCache();

        services.AddSingleton<IDistributedCacheProvider, DistributedCacheProvider>();

        services.Configure<Settings>(Configuration.GetSection(nameof(Settings)));

        services.Configure<DistributedCacheOptions>(Configuration.GetSection(nameof(DistributedCacheOptions)));
    }
}