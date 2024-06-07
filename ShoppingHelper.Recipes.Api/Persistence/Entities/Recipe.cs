using Shared.Enums;

namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Recipe
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Recipe()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        
    }

    public Recipe(
        string id,
        bool active,
        string name,
        string headline,
        string description,
        int difficulty,
        string imageLink,
        string imagePath,
        string prepTime,
        string totalTime,
        string slug,
        string uniqueRecipeCode,
        Guid uuid,
        string link,
        string websiteUrl,
        DateTime createdAt,
        DateTime updatedAt,
        ICollection<Allergen> allergens,
        ICollection<Cuisine> cuisines,
        ICollection<Ingredient> ingredients,
        ICollection<Tag> tags,
        ICollection<Step> steps,
        ICollection<Yield> yields)
    {
        Id = id;
        Active = active;
        Name = name;
        Headline = headline;
        Description = description;
        Difficulty = difficulty;
        ImageLink = imageLink;
        ImagePath = imagePath;
        PrepTime = prepTime;
        TotalTime = totalTime;
        Slug = slug;
        UniqueRecipeCode = uniqueRecipeCode;
        Uuid = uuid;
        Link = link;
        WebsiteUrl = websiteUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Allergens = allergens;
        Cuisines = cuisines;
        Ingredients = ingredients;
        Tags = tags;
        Steps = steps;
        Yields = yields;
    }

    public string Id { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; }
    public string Headline { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public string ImageLink { get; set; }
    public string ImagePath { get; set; }
    public string PrepTime { get; set; }
    public string TotalTime { get; set; }
    public string Slug { get; set; }
    public string UniqueRecipeCode { get; set; }
    public Guid Uuid { get; set; }
    public string Link { get; set; }
    public string WebsiteUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public RecipeSource Source { get; set; }

    public ICollection<Allergen> Allergens { get; set; } = [];
    public ICollection<Cuisine> Cuisines { get; set; } = [];
    public ICollection<Ingredient> Ingredients { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Step> Steps { get; set; } = [];
    public ICollection<Yield> Yields { get; set; } = [];

}
