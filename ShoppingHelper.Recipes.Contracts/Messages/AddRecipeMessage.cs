namespace ShoppingHelper.Recipes.Contracts.Messages;
public record AddRecipeMessage(RecipeDto Recipe);

public record RecipeDto(
    string Id,
    bool Active,
    string Name,
    string Headline,
    string Description,
    int Difficulty,
    string ImageLink,
    string ImagePath,
    string PrepTime,
    string TotalTime,
    string Slug,
    string UniqueRecipeCode,
    Guid Uuid,
    string Link,
    string WebsiteUrl,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    IEnumerable<YieldDto> Yields,
    IEnumerable<StepDto> Steps,
    IEnumerable<TagDto> Tags,
    IEnumerable<CuisineDto> Cuisines);

public record IngredientDto(string Id, Guid Uuid, string Name, string Type, string Slug, string Imagelink, string ImagePath, IEnumerable<AllergenDto> Allergens);

public record StepDto(int Index, string Instructions, string ImageLink, string ImagePath);

public record YieldDto(double Amount, string Unit, IngredientDto Ingredient);

public record TagDto(string Id, string Type, string Name, string Slug);

public record CuisineDto(string Id, string Type, string Name, string Slug, string IconLink);

public record AllergenDto(string Id, string Name, string Type, string Slug, string IconLink, string IconPath, bool TriggersTracesOf, bool TracesOf);

