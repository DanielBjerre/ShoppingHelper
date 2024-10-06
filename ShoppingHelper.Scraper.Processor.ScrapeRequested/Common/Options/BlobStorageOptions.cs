using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.Processor.ScrapeRequested.Common.Options;

public class HelloFreshBlobStorageOptions
{
    public const string Section = "HelloFreshBlobStorag";

    [Required]
    public required string ServiceUri { get; set; }
    [Required]
    public required string HelloFreshAccessTokenContainer { get; set; }
    [Required]
    public required string HelloFreshAccessTokenBlob { get; set; }
}