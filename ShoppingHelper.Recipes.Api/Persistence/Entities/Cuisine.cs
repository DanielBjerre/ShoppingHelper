namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Cuisine(
    string id,
    string type,
    string name,
    string slug,
    string iconLink)
{
    public string Id { get; set; } = id;
    public string Type { get; set; } = type;
    public string Name { get; set; } = name;
    public string Slug { get; set; } = slug;
    public string IconLink { get; set; } = iconLink;
}
