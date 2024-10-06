using ShoppingHelper.Scraper.Api.Services.HelloFreshService.Models;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshService;

public interface IHelloFreshService
{
    public IAsyncEnumerable<Recipe> GetRecipes(CancellationToken cancellationToken);
}
