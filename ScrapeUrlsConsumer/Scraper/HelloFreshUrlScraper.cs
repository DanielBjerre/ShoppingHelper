using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using ScrapeService.Shared.Options;
using SeleniumExtras.WaitHelpers;

namespace ScrapeUrlsConsumer.Scraper;
internal sealed class HelloFreshUrlScraper(IOptions<SeleniumOptions> seleniumOptions) : UrlScraper(seleniumOptions)
{
    private readonly string _recipeBaseUrl = "https://www.hellofresh.dk/recipes";

    protected override IEnumerable<Uri> GetUrls()
    {
        LoadAllRecipes();
        var cards = _driver.FindElements(By.CssSelector("[data-test-id=\"recipe-image-card\""));

        foreach (var card in cards)
        {
            var element = card.FindElement(By.CssSelector(":first-child"));
            var href = element.GetAttribute("href");
            if (!href.StartsWith(_recipeBaseUrl))
            {
                continue;
            }

            var url = element.GetAttribute("href");
            yield return new Uri(url);
        }
    }

    private void LoadAllRecipes()
    {
        try
        {
            var loadMoreButton = _driverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[data-test-id=\"load-more-cta\"]")));
            while (true)
            {
                try
                {
                    loadMoreButton.Click();
                }
                catch (StaleElementReferenceException)
                {
                    loadMoreButton = _driverWait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[data-test-id=\"load-more-cta\"]")));
                }
                
            }
        }
        catch (WebDriverTimeoutException)
        {
            return;
        }
    }
}