namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshAccessTokenService;

public interface IHelloFreshAccessTokenService
{
    public Task<string> GetAccessToken(CancellationToken cancellationToken);
}
