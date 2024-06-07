using MassTransit;
using ScrapeService.Contracts;
using ScrapeUrlsConsumer.Scraper;

namespace ScrapeUrlsConsumer;
internal class Consumer(
    ILogger<Consumer> logger,
    IServiceScopeFactory serviceScopeFactory) : IConsumer<ScrapeUrls>
{
    private readonly ILogger<Consumer> _logger = logger;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    public async Task Consume(ConsumeContext<ScrapeUrls> context)
    {
        _logger.LogInformation("Scraping urls from {uri}", context.Message.Url);

        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var scraper = scope.ServiceProvider.GetRequiredService<HelloFreshUrlScraper>();

        var urls = scraper.ScrapeUrls(new Uri(context.Message.Url));

        foreach (var url in urls)
        {
            await context.Publish(new ScrapeRecipe(url));
        }
    }
}
