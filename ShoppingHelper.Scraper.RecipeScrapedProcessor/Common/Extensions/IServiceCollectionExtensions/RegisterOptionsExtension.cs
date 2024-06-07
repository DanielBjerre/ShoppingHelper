using ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Options;

namespace ShoppingHelper.Scraper.RecipeScrapedProcessor.Common.Extensions.IServiceCollectionExtensions;
public static class RegisterOptionsExtension
{
    public static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.AddOptionsWithValidateOnStart<CosmosOptions>()
            .BindConfiguration(CosmosOptions.Section)
            .ValidateDataAnnotations();

        services.AddOptionsWithValidateOnStart<MassTransitOptions>()
            .BindConfiguration(MassTransitOptions.Section)
            .ValidateDataAnnotations();

        return services;
    }
}
