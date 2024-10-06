using Azure.Identity;
using MassTransit;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;
using System.Reflection;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Extensions.IServiceCollectionExtensions;
public static class RegisterMassTransitExtension
{
    public static IServiceCollection RegisterMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceBusHostName = configuration.GetRequiredSection(MassTransitOptions.Section)[nameof(MassTransitOptions.ServiceBusHostName)];

        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetExecutingAssembly());

            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(new Uri($"sb://{serviceBusHostName}"), o =>
                {
                    o.TokenCredential = new DefaultAzureCredential();
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
