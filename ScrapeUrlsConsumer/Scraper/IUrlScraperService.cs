namespace ScrapeUrlsConsumer.Scraper;
internal interface IUrlScraper
{
    public string RecipeSource { get; set; }
    public IEnumerable<Uri> ScrapeUrls { get; set; }
}
