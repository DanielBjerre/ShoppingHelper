using System.ComponentModel.DataAnnotations;

namespace ShoppingHelper.Scraper.Api.Common.Options;

public class CosmosOptions
{
    public const string Section = "Cosmos";

    [Required]
    public required string Endpoint { get; set; }
    [Required]
    public required string Database { get; set; }
    [Required]
    public required Containers Containers { get; set; }
}

public class Containers
{
    [Required]
    public required string HelloFresh { get; set; }
}