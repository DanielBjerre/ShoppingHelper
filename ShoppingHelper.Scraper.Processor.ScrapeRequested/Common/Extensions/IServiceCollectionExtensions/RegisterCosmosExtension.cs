using Azure.Identity;
using Microsoft.Azure.Cosmos;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Extensions.IServiceCollectionExtensions;

public static class RegisterCosmosExtension
{
    public static IServiceCollection RegisterCosmos(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsWithValidateOnStart<CosmosOptions>()
            .BindConfiguration(CosmosOptions.Section)
            .ValidateDataAnnotations();

        var options = new CosmosClientOptions { AllowBulkExecution = true };
        var client = new CosmosClient(configuration.GetRequiredSection(CosmosOptions.Section)[nameof(CosmosOptions.Endpoint)], new DefaultAzureCredential(), options);
        services.AddSingleton(client);

        return services;
    }
}
