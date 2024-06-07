using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Options;
public class CosmosOptions
{
    public const string Section = "Cosmos";

    [Required]
    public required string Endpoint { get; set; }
    [Required]
    public required string Database { get; set; }
    [Required]
    public required string Container { get; set; }
    [Required]
    public required string LeaseContainer { get; set; }
}
