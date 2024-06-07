//// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
//using System.Text.Json.Serialization;

//namespace ShoppingHelper.Recipes.Api.Common;

//public record Allergen(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("iconLink")] string IconLink,
//    [property: JsonPropertyName("iconPath")] string IconPath,
//    [property: JsonPropertyName("triggersTracesOf")] bool? TriggersTracesOf,
//    [property: JsonPropertyName("tracesOf")] bool? TracesOf
//);

//public record Cuisine(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("iconLink")] string IconLink
//);

//public record Family(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("uuid")] string Uuid,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("priority")] int? Priority,
//    [property: JsonPropertyName("iconLink")] object IconLink,
//    [property: JsonPropertyName("iconPath")] object IconPath
//);

//public record Image(
//    [property: JsonPropertyName("link")] string Link,
//    [property: JsonPropertyName("path")] string Path,
//    [property: JsonPropertyName("caption")] string Caption
//);

//public record Ingredient(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("uuid")] string Uuid,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("country")] string Country,
//    [property: JsonPropertyName("imageLink")] string ImageLink,
//    [property: JsonPropertyName("imagePath")] string ImagePath,
//    [property: JsonPropertyName("shipped")] bool? Shipped,
//    [property: JsonPropertyName("allergens")] IReadOnlyList<string> Allergens,
//    [property: JsonPropertyName("family")] Family Family,
//    [property: JsonPropertyName("amount")] double? Amount,
//    [property: JsonPropertyName("unit")] string Unit
//);

//public record Item(
//    [property: JsonPropertyName("active")] bool? Active,
//    [property: JsonPropertyName("allergens")] IReadOnlyList<Allergen> Allergens,
//    [property: JsonPropertyName("averageRating")] double? AverageRating,
//    [property: JsonPropertyName("canonical")] object Canonical,
//    [property: JsonPropertyName("canonicalLink")] object CanonicalLink,
//    [property: JsonPropertyName("cardLink")] object CardLink,
//    [property: JsonPropertyName("category")] object Category,
//    [property: JsonPropertyName("clonedFrom")] string ClonedFrom,
//    [property: JsonPropertyName("comment")] object Comment,
//    [property: JsonPropertyName("country")] string Country,
//    [property: JsonPropertyName("createdAt")] DateTime? CreatedAt,
//    [property: JsonPropertyName("cuisines")] IReadOnlyList<Cuisine> Cuisines,
//    [property: JsonPropertyName("description")] string Description,
//    [property: JsonPropertyName("descriptionHTML")] string DescriptionHTML,
//    [property: JsonPropertyName("descriptionMarkdown")] string DescriptionMarkdown,
//    [property: JsonPropertyName("difficulty")] int? Difficulty,
//    [property: JsonPropertyName("favoritesCount")] int? FavoritesCount,
//    [property: JsonPropertyName("headline")] string Headline,
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("imageLink")] string ImageLink,
//    [property: JsonPropertyName("imagePath")] string ImagePath,
//    [property: JsonPropertyName("ingredients")] IReadOnlyList<Ingredient> Ingredients,
//    [property: JsonPropertyName("isAddon")] bool? IsAddon,
//    [property: JsonPropertyName("isComplete")] object IsComplete,
//    [property: JsonPropertyName("label")] Label Label,
//    [property: JsonPropertyName("link")] string Link,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("nutrition")] IReadOnlyList<Nutrition> Nutrition,
//    [property: JsonPropertyName("prepTime")] string PrepTime,
//    [property: JsonPropertyName("promotion")] object Promotion,
//    [property: JsonPropertyName("ratingsCount")] int? RatingsCount,
//    [property: JsonPropertyName("seoDescription")] object SeoDescription,
//    [property: JsonPropertyName("seoName")] object SeoName,
//    [property: JsonPropertyName("servingSize")] int? ServingSize,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("steps")] IReadOnlyList<Step> Steps,
//    [property: JsonPropertyName("tags")] IReadOnlyList<Tag> Tags,
//    [property: JsonPropertyName("totalTime")] string TotalTime,
//    [property: JsonPropertyName("uniqueRecipeCode")] string UniqueRecipeCode,
//    [property: JsonPropertyName("updatedAt")] DateTime? UpdatedAt,
//    [property: JsonPropertyName("utensils")] IReadOnlyList<Utensil> Utensils,
//    [property: JsonPropertyName("uuid")] string Uuid,
//    [property: JsonPropertyName("videoLink")] object VideoLink,
//    [property: JsonPropertyName("websiteUrl")] string WebsiteUrl,
//    [property: JsonPropertyName("yields")] IReadOnlyList<Yield> Yields
//);

//public record Label(
//    [property: JsonPropertyName("text")] string Text,
//    [property: JsonPropertyName("handle")] string Handle,
//    [property: JsonPropertyName("foregroundColor")] string ForegroundColor,
//    [property: JsonPropertyName("backgroundColor")] string BackgroundColor,
//    [property: JsonPropertyName("displayLabel")] bool? DisplayLabel
//);

//public record Nutrition(
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("amount")] double? Amount,
//    [property: JsonPropertyName("unit")] string Unit
//);

//public record Root(
//    [property: JsonPropertyName("items")] IReadOnlyList<Item> Items,
//    [property: JsonPropertyName("take")] int? Take,
//    [property: JsonPropertyName("skip")] int? Skip,
//    [property: JsonPropertyName("count")] int? Count,
//    [property: JsonPropertyName("total")] int? Total
//);

//public record Step(
//    [property: JsonPropertyName("index")] int? Index,
//    [property: JsonPropertyName("instructions")] string Instructions,
//    [property: JsonPropertyName("instructionsHTML")] string InstructionsHTML,
//    [property: JsonPropertyName("instructionsMarkdown")] string InstructionsMarkdown,
//    [property: JsonPropertyName("ingredients")] IReadOnlyList<object> Ingredients,
//    [property: JsonPropertyName("utensils")] IReadOnlyList<string> Utensils,
//    [property: JsonPropertyName("timers")] IReadOnlyList<object> Timers,
//    [property: JsonPropertyName("images")] IReadOnlyList<Image> Images,
//    [property: JsonPropertyName("videos")] IReadOnlyList<object> Videos
//);

//public record Tag(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("name")] string Name,
//    [property: JsonPropertyName("slug")] string Slug,
//    [property: JsonPropertyName("colorHandle")] string ColorHandle,
//    [property: JsonPropertyName("preferences")] IReadOnlyList<string> Preferences,
//    [property: JsonPropertyName("displayLabel")] bool? DisplayLabel
//);

//public record Utensil(
//    [property: JsonPropertyName("id")] string Id,
//    [property: JsonPropertyName("type")] string Type,
//    [property: JsonPropertyName("name")] string Name
//);

//public record Yield(
//    [property: JsonPropertyName("yields")] int? Yields,
//    [property: JsonPropertyName("ingredients")] IReadOnlyList<Ingredient> Ingredients
//);