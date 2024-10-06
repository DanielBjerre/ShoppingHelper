//using MediatR;
//using Microsoft.Azure.Cosmos;
//using Microsoft.Extensions.Options;
//using ShoppingHelper.Scraper.Api.Common.Options;
//using ShoppingHelper.Scraper.Api.Services.HelloFreshService;
//using ShoppingHelper.Scraper.Api.Services.HelloFreshService.Models;

//namespace ShoppingHelper.Scraper.Api.Features.Scrape.HelloFresh;

//public class ScrapeHelloFreshHandler(
//    IHelloFreshService helloFreshService,
//    CosmosClient cosmosClient,
//    IOptions<CosmosOptions> cosmosOptions) : IRequestHandler<ScrapeHelloFreshQuery, ScrapeHelloFreshResponse>
//{
//    private readonly IHelloFreshService _helloFreshService = helloFreshService;
//    private readonly CosmosClient _cosmosClient = cosmosClient;
//    private readonly IOptions<CosmosOptions> _cosmosOptions = cosmosOptions;

//    public async Task<ScrapeHelloFreshResponse> Handle(ScrapeHelloFreshQuery request, CancellationToken cancellationToken)
//    {
//        var helloFreshContainer = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.Containers.HelloFresh);

//        var recipes = _helloFreshService.GetRecipes(cancellationToken);

//        var upsertTasks = new List<Task<ItemResponse<Recipe>>>();

//        await foreach (var recipe in recipes)
//        {
//            upsertTasks.Add(helloFreshContainer.UpsertItemAsync(recipe, cancellationToken: cancellationToken));
//        }

//        await Task.WhenAll(upsertTasks);

//        var result = new ScrapeHelloFreshResponse(upsertTasks.Count);

//        return result;
//    }
//}


