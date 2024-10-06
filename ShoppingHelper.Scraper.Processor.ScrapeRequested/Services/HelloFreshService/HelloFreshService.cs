using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using ShoppingHelper.Scraper.Api.Services.HelloFreshService.Models;
using ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshService;

public class HelloFreshService(IOptions<HelloFreshOptions> _helloFreshOptions, HttpClient httpClient) : IHelloFreshService
{
    private readonly IOptions<HelloFreshOptions> _helloFreshOptions = _helloFreshOptions;
    private readonly HttpClient _httpClient = httpClient;

    public async IAsyncEnumerable<Recipe> GetRecipes([EnumeratorCancellation] CancellationToken cancellationToken)
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

        do
        {
            var paginationParams = new Dictionary<string, string>()
            {
                { nameof(skip), skip.ToString() },
                { nameof(take), take.ToString() },
            };
            var getRecipesQuery = QueryHelpers.AddQueryString(baseQuery, paginationParams!);

            getRecipesResult = await _httpClient.GetFromJsonAsync<HelloFreshGetRecipesResult>(getRecipesQuery, cancellationToken);
            skip += take;

            foreach (var item in getRecipesResult!.Items)
            {
                yield return item;
            }

        } while (getRecipesResult!.Total > skip);
    }
}
