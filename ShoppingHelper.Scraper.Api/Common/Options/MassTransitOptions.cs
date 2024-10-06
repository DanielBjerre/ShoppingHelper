using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Options;
internal class MassTransitOptions
{
    public const string Section = "MassTransit";

    [Required]
    public required string ServiceBusHostName { get; set; }
}
