namespace ScrapeUrlsConsumer.Scraper;
internal interface IUrlScraperService
{
    public string RecipeSource { get; set; }
    public IEnumerable<Uri> ScrapeUrls { get; set; }
}
