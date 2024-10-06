using MassTransit;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Shared.Enums;
using ShoppingHelper.Scraper.Contracts.Events;
using ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Options;

namespace ShoppingHelper.Scraper.RecipeScrapedProcessor;

public class Worker(
    ILogger<Worker> logger,
    CosmosClient cosmosClient,
    IOptions<CosmosOptions> cosmosOptions,
    IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly CosmosClient _cosmosClient = cosmosClient;
    private readonly IOptions<CosmosOptions> _cosmosOptions = cosmosOptions;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosOptions.Value.Database, cancellationToken: stoppingToken);

        var leaseContainer = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.LeaseContainer);
        var changeFeedProcessor = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.Container)
            .GetChangeFeedProcessorBuilder<IdModel>(processorName: "recipeScrapedProcessor", onChangesDelegate: HandleChangesAsync)
                .WithInstanceName("recipeScrapedProcessorWorker")
                .WithLeaseContainer(leaseContainer)
                .Build();

        _logger.LogInformation("Starting Change Feed Processor.");
        await changeFeedProcessor.StartAsync();
        _logger.LogInformation("Change Feed Processor started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }

        await changeFeedProcessor.StopAsync();
        _logger.LogInformation("Change Feed Processor stopped.");
    }

    private async Task HandleChangesAsync(IReadOnlyCollection<IdModel> changes, CancellationToken cancellationToken)
    {
        using var  scope = _serviceScopeFactory.CreateScope();
        var publishEndpoint = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();
        var events = changes.Select(x => new RecipeScrapedEvent(RecipeSource.HelloFresh, x.Id));
        await publishEndpoint.PublishBatch(events, cancellationToken);
        _logger.LogInformation("Published {amountOfIds} recipeIds", changes.Count);
    }

    private record IdModel(string Id);
}
