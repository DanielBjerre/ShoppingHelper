using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;

public class HelloFreshOptions
{
    public const string Section = "HelloFresh";

    [Required]
    public required string BaseAddress { get; set; }
    [Required]
    public required string RecipesUrl { get; set; }
    [Required]
    public required string Country { get; set; }
    [Required]
    public required string Locale { get; set; }
    [Required]
    public required string Product { get; set; }
}
