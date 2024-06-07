namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Tag(
    string id,
    string type,
    string name,
    string slug)
{
    public string Id { get; set; } = id;
    public string Type { get; set; } = type;
    public string Name { get; set; } = name;
    public string Slug { get; set; } = slug;
}
