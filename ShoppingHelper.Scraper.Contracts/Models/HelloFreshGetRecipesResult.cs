// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace ShoppingHelper.Scraper.Contracts.Models
{
    public record Allergen(
    string Id,
    string Name,
    string Type,
    string Slug,
    string IconLink,
    string IconPath,
    bool? TriggersTracesOf,
    bool? TracesOf
    );

    public record Cuisine(
    string Id,
    string Type,
    string Name,
    string Slug,
    string IconLink
    );

    public record Family(
    string Id,
    string Uuid,
    string Name,
    string Slug,
    string Type,
    int? Priority,
    object IconLink,
    object IconPath
    );

    public record Image(
    string Link,
    string Path,
    string Caption
    );

    public record Ingredient(
    string Id,
    string Uuid,
    string Name,
    string Type,
    string Slug,
    string Country,
    string ImageLink,
    string ImagePath,
    bool? Shipped,
    IReadOnlyList<string> Allergens,
    Family Family,
    double? Amount,
    string Unit
    );

    public record Item(
    bool? Active,
    IReadOnlyList<Allergen> Allergens,
    double? AverageRating,
    object Canonical,
    object CanonicalLink,
    object CardLink,
    object Category,
    string ClonedFrom,
    object Comment,
    string Country,
    DateTime? CreatedAt,
    IReadOnlyList<Cuisine> Cuisines,
    string Description,
    string DescriptionHTML,
    string DescriptionMarkdown,
    int? Difficulty,
    int? FavoritesCount,
    string Headline,
    string id,
    string ImageLink,
    string ImagePath,
    IReadOnlyList<Ingredient> Ingredients,
    bool? IsAddon,
    object IsComplete,
    Label Label,
    string Link,
    string Name,
    IReadOnlyList<Nutrition> Nutrition,
    string PrepTime,
    object Promotion,
    int? RatingsCount,
    object SeoDescription,
    object SeoName,
    int? ServingSize,
    string Slug,
    IReadOnlyList<Step> Steps,
    IReadOnlyList<Tag> Tags,
    string TotalTime,
    string UniqueRecipeCode,
    DateTime? UpdatedAt,
    IReadOnlyList<Utensil> Utensils,
    string Uuid,
    object VideoLink,
    string WebsiteUrl,
    IReadOnlyList<Yield> Yields
    );

    public record Label(
    string Text,
    string Handle,
    string ForegroundColor,
    string BackgroundColor,
    bool? DisplayLabel
    );

    public record Nutrition(
    string Type,
    string Name,
    double? Amount,
    string Unit
    );

    public record HelloFreshGetRecipesResult(
    IReadOnlyList<Item> Items,
    int? Take,
    int? Skip,
    int? Count,
    int? Total
    );

    public record Step(
    int? Index,
    string Instructions,
    string InstructionsHTML,
    string InstructionsMarkdown,
    IReadOnlyList<object> Ingredients,
    IReadOnlyList<string> Utensils,
    IReadOnlyList<object> Timers,
    IReadOnlyList<Image> Images,
    IReadOnlyList<object> Videos
    );

    public record Tag(
    string Id,
    string Type,
    string Name,
    string Slug,
    string ColorHandle,
    IReadOnlyList<string> Preferences,
    bool? DisplayLabel
    );

    public record Utensil(
    string Id,
    string Type,
    string Name
    );

    public record Yield(
    int? Yields,
    IReadOnlyList<Ingredient> Ingredients
    );
}