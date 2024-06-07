namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Allergen(
    string id,
    string name,
    string type,
    string slug,
    string iconLink,
    string iconPath,
    bool triggersTracesOf,
    bool tracesOf)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;
    public string Slug { get; set; } = slug;
    public string IconLink { get; set; } = iconLink;
    public string IconPath { get; set; } = iconPath;
    public bool TriggersTracesOf { get; set; } = triggersTracesOf;
    public bool TracesOf { get; set; } = tracesOf;
}
