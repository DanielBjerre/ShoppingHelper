namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Ingredient
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Ingredient()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        
    }

    public Ingredient(
        string id,
        Guid uuid,
        string name,
        string type,
        string slug,
        string imageLink,
        string imagePath,
        ICollection<Allergen> allergens)
    {
        Id = id;
        Uuid = uuid;
        Name = name;
        Type = type;
        Slug = slug;
        ImageLink = imageLink;
        ImagePath = imagePath;
        Allergens = allergens;
    }

    public string Id { get; set; }
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Slug { get; set; }
    public string ImageLink { get; set; }
    public string ImagePath { get; set; }

    public ICollection<Allergen> Allergens { get; set; } = [];

}
