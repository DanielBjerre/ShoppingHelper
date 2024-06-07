using Azure.Identity;
using Microsoft.Azure.Cosmos;
using ShoppingHelper.Scraper.Api.Common.Options;

namespace ShoppingHelper.Scraper.Api.Common.Extensions.IServiceCollectionExtensions;

public static class RegisterCosmosClientExtension
{
    public static IServiceCollection RegisterCosmosClient(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new CosmosClientOptions { AllowBulkExecution = true };
        var client = new CosmosClient(configuration.GetRequiredSection(CosmosOptions.Section)[nameof(CosmosOptions.Endpoint)], new DefaultAzureCredential(), options);
        services.AddSingleton(client);

        return services;
    }
}
