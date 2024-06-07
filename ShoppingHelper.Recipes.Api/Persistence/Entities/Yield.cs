namespace ShoppingHelper.Recipes.Api.Persistence.Entities;

public class Yield(
    string ingredientId,
    double amount,
    string unit,
    Ingredient ingredient)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Amount { get; set; } = amount;
    public string Unit { get; set; } = unit;

    public string IngredientId { get; set; } = ingredientId;
    public Ingredient Ingredient { get; set; } = ingredient;
}
