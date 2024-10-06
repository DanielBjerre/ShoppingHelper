using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Api.Common.Options;
using ShoppingHelper.Scraper.Api.Services.HelloFreshService.Models;
using System.Text.Json;

namespace ShoppingHelper.Scraper.Api.Features.Recipes.GetRecipe;

public class GetRecipeHandler(
    CosmosClient cosmosClient,
    IOptions<CosmosOptions> cosmosOptions) : IRequestHandler<GetRecipeQuery, GetRecipeResponse>
{
    private readonly CosmosClient _cosmosClient = cosmosClient;
    private readonly IOptions<CosmosOptions> _cosmosOptions = cosmosOptions;


    public async Task<GetRecipeResponse> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        var container = _cosmosClient.GetContainer(_cosmosOptions.Value.Database, _cosmosOptions.Value.Containers.HelloFresh);

        var recipe = await container.ReadItemAsync<Recipe>(request.RecipeId, new PartitionKey(request.RecipeId), cancellationToken: cancellationToken);

        var response = new GetRecipeResponse(recipe);

        return response;
    }
}
