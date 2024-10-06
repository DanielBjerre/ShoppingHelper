using MediatR;

namespace ShoppingHelper.Scraper.Api.Features.Scrape.HelloFresh;

public record ScrapeHelloFreshQuery() : IRequest<ScrapeHelloFreshResponse>;

