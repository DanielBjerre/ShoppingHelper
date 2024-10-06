using MassTransit;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Api.Services.HelloFreshService.Models;
using ShoppingHelper.Scraper.Contracts.Commands;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshService;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested;

public class ScrapeRequestedConsumer(

    IHelloFreshService helloFreshService,
    CosmosClient cosmosClient,
    IOptions<CosmosOptions> cosmosOptions) : IConsumer<ScrapeRequestedCommand>
{
    private readonly IHelloFreshService _helloFreshService = helloFreshService;
    private readonly CosmosClient _cosmosClient = cosmosClient;
    private readonly IOptions<CosmosOptions> _cosmosOptions = cosmosOptions;

    public async Task Consume(ConsumeContext<ScrapeRequestedCommand> context)
    {
        var helloFreshContainer = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.Containers.HelloFresh);

        var recipes = _helloFreshService.GetRecipes(context.CancellationToken);

        var upsertTasks = new List<Task<ItemResponse<Recipe>>>();

        await foreach (var recipe in recipes)
        {
            upsertTasks.Add(helloFreshContainer.UpsertItemAsync(recipe, cancellationToken: context.CancellationToken));
        }

        await Task.WhenAll(upsertTasks);
    }
}
