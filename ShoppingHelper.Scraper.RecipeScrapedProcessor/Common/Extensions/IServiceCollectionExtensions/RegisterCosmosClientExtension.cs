using Azure.Identity;
using Microsoft.Azure.Cosmos;
using ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Options;

namespace ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Extensions.IServiceCollectionExtensions;

public static class RegisterCosmosClientExtension
{
    public static IServiceCollection RegisterCosmosClient(this IServiceCollection services, IConfiguration configuration)
    {;
        var client = new CosmosClient(configuration.GetRequiredSection(CosmosOptions.Section)[nameof(CosmosOptions.Endpoint)], new DefaultAzureCredential());
        services.AddSingleton(client);

        return services;
    }
}
