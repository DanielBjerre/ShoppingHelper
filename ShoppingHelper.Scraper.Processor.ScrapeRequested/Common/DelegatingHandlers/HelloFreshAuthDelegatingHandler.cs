using ShoppingHelper.Scraper.Processor.ScrapeRequested.Services.HelloFreshAccessTokenService;
using System.Net.Http.Headers;

internal class HelloFreshAuthDelegatingHandler(IHelloFreshAccessTokenService helloFreshAccessTokenService) : DelegatingHandler
{
    private readonly IHelloFreshAccessTokenService _helloFreshAccessTokenService = helloFreshAccessTokenService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", await _helloFreshAccessTokenService.GetAccessToken(cancellationToken));
        return await base.SendAsync(request, cancellationToken);
    }
}