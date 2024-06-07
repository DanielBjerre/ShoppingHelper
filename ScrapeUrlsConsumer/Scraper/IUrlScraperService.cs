namespace ScrapeUrlsConsumer.Scraper;
internal interface IUrlScraper
{
    public IEnumerable<Uri> ScrapeUrls(Uri uri);
}
