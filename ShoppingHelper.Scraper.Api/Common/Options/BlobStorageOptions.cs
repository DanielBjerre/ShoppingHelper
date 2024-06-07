using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.Api.Common.Options;

public class BlobStorageOptions
{
    public const string Section = "BlobStorage";

    [Required]
    public required string ServiceUri { get; set; }
    [Required]
    public required string HelloFreshAccessTokenContainer { get; set; }
    [Required]
    public required string HelloFreshAccessTokenBlob { get; set; }
}