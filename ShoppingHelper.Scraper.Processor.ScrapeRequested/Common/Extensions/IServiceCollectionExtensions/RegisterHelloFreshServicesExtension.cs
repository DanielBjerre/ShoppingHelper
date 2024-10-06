using Azure.Identity;
using Microsoft.Extensions.Azure;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshAccessTokenService;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshService;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Extensions.IServiceCollectionExtensions;
public static class RegisterHelloFreshServicesExtension
{
    public static IServiceCollection RegisterHelloFreshServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.UseCredential(new DefaultAzureCredential());
            clientBuilder.AddBlobServiceClient(configuration.GetRequiredSection(HelloFreshBlobStorageOptions.Section));
        });

        services.AddOptionsWithValidateOnStart<HelloFreshBlobStorageOptions>()
            .BindConfiguration(HelloFreshBlobStorageOptions.Section)
            .ValidateDataAnnotations();

        services.AddTransient<HelloFreshAuthDelegatingHandler>();
        services.AddOptionsWithValidateOnStart<HelloFreshOptions>()
            .BindConfiguration(HelloFreshOptions.Section)
            .ValidateDataAnnotations();

        services.AddScoped<IHelloFreshAccessTokenService, HardCodedHelloFreshAccessTokenService>();
        services.AddScoped<IHelloFreshService, HelloFreshService>();

        services.AddHttpClient<IHelloFreshService, HelloFreshService>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetRequiredSection(HelloFreshOptions.Section)[nameof(HelloFreshOptions.BaseAddress)]!);
        })
        .AddHttpMessageHandler<HelloFreshAuthDelegatingHandler>();

        return services;
    }
}
