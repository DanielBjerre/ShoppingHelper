namespace ShoppingHelper.Scraper.Api.Services.HelloFreshAccessTokenService;

public interface IHelloFreshAccessTokenService
{
    public Task<string> GetAccessToken(CancellationToken cancellationToken);
}
