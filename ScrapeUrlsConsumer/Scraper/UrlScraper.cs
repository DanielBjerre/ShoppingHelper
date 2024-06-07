using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using ScrapeService.Shared.Options;

namespace ScrapeUrlsConsumer.Scraper;
internal abstract class UrlScraper(IOptions<SeleniumOptions> seleniumOptions)
{
    protected virtual TimeSpan WebDriverWaitTime { get; } = TimeSpan.FromSeconds(20);

    private readonly IOptions<SeleniumOptions> _seleniumOptions = seleniumOptions;

    protected RemoteWebDriver _driver = null!;
    protected WebDriverWait _driverWait = null!;

    public IEnumerable<Uri> ScrapeUrls(Uri uri)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");

        _driver = new RemoteWebDriver(new Uri(_seleniumOptions.Value.Url), options);
        _driverWait = new WebDriverWait(_driver, WebDriverWaitTime);

        _driver.Navigate()
            .GoToUrl(uri);

        var urls = GetUrls();
        _driver.Quit();
        return urls;
    }

    protected abstract IEnumerable<Uri> GetUrls();
}
