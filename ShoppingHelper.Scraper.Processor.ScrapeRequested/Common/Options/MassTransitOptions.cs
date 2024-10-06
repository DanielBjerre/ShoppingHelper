using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;
internal class MassTransitOptions
{
    public const string Section = "MassTransit";

    [Required]
    public required string ServiceBusHostName { get; set; }
}
