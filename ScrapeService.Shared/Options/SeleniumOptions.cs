using System.ComponentModel.DataAnnotations;

namespace ScrapeService.Shared.Options;
public sealed class SeleniumOptions
{
    public const string Section = "Selenium";

    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string BaseUrl { get; set; } = string.Empty;

    public string Url => $"https://{Username}:{Password}@{BaseUrl}";
}
