using MediatR;
using Shared.Enums;

namespace ShoppingHelper.Scraper.Api.Features.Scrape.Request;

public record ScrapeRequestCommand(RecipeSource RecipeSource) : IRequest<ScrapeRequestResponse>;
