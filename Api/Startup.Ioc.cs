using Domain.Configuration;
using Domain.Ports;
using Domain.Services;
using Infrastructure.DistributedCaches;
using Infrastructure.HttpClients;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public partial class Startup
    {
        private void ConfigureIoc(IServiceCollection services)
        {
            services.AddScoped<DummyMessageHandler>();

            services.AddScoped<IDummyService, DummyService>();

            services.AddHttpClient<IDummyClient, DummyClient>()
                .AddHttpMessageHandler<DummyMessageHandler>();

            services.AddDistributedMemoryCache();

            services.AddTransient<IDistributedCacheProvider, DistributedCacheProvider>();

            services.AddSingleton<IWebSiteCacheProvider, WebSiteCacheProvider>();

            services.Configure<Settings>(Configuration.GetSection(nameof(Settings)));

            services.Configure<DistributedCacheOptions>(Configuration.GetSection(nameof(DistributedCacheOptions)));
        }
    }
}
