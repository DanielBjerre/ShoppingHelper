using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Api.Common.Options;
using ShoppingHelper.Scraper.Contracts.Models;

namespace ShoppingHelper.Scraper.Api.Features.ScrapeRecipes.HelloFreshRecipes;

public record ScrapeHelloFreshRecipesQuery() : IRequest<ScrapeHelloFreshRecipesResult>;

public record ScrapeHelloFreshRecipesResult(int Count);

public class ScrapeHelloFreshRecipesHandler(
    HttpClient httpClient,
    IOptions<HelloFreshOptions> helloFreshOptions,
    CosmosClient cosmosClient,
    IOptions<CosmosOptions> cosmosOptions) : IRequestHandler<ScrapeHelloFreshRecipesQuery, ScrapeHelloFreshRecipesResult>
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IOptions<HelloFreshOptions> _helloFreshOptions = helloFreshOptions;
    private readonly CosmosClient _cosmosClient = cosmosClient;
    private readonly IOptions<CosmosOptions> _cosmosOptions = cosmosOptions;

    public async Task<ScrapeHelloFreshRecipesResult> Handle(ScrapeHelloFreshRecipesQuery request, CancellationToken cancellationToken)
    {
        var skip = 0;
        var take = 250;

        var baseParams = new Dictionary<string, string>
        {
            { nameof(HelloFreshOptions.Country).ToLower(), _helloFreshOptions.Value.Country },
            { nameof(HelloFreshOptions.Locale).ToLower(), _helloFreshOptions.Value.Locale },
            { nameof(HelloFreshOptions.Product).ToLower(), _helloFreshOptions.Value.Product },
            
        };

        var baseQuery = QueryHelpers.AddQueryString(_helloFreshOptions.Value.RecipesUrl, baseParams!);

        HelloFreshGetRecipesResult? getRecipesResult;

        var recipes = new List<Item>();

        do
        {
            var paginationParams = new Dictionary<string, string>()
            {
                { nameof(skip), skip.ToString() },
                { nameof(take), take.ToString() },
            };

            var getRecipesQuery = QueryHelpers.AddQueryString(baseQuery, paginationParams!);

            var test = await _httpClient.GetAsync(getRecipesQuery, cancellationToken);
            getRecipesResult = await _httpClient.GetFromJsonAsync<HelloFreshGetRecipesResult>(getRecipesQuery, cancellationToken);
            recipes.AddRange(getRecipesResult!.Items);
            skip += take;
        } while (getRecipesResult!.Total > skip);


        var helloFreshContainer = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.Containers.HelloFresh);

        var upsertTasks = new List<Task<ItemResponse<Item>>>();

        foreach (var recipe in recipes)
        {
            upsertTasks.Add(helloFreshContainer.UpsertItemAsync(recipe, cancellationToken: cancellationToken));
        }

        await Task.WhenAll(upsertTasks);

        var result = new ScrapeHelloFreshRecipesResult(recipes.Count);

        return result;
    }
}


