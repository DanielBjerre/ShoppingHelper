using Shared.Enums;

namespace ShoppingHelper.Scraper.Contracts.Events;
public record RecipeScrapedEvent(RecipeSource RecipeSource, string Identifier);
