namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Step(
    int index,
    string instructions,
    string imageLink,
    string imagePath)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Index { get; set; } = index;
    public string Instructions { get; set; } = instructions;
    public string ImageLink { get; set; } = imageLink;
    public string ImagePath { get; set; } = imagePath;
}
