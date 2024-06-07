using Microsoft.EntityFrameworkCore;
using ShoppingHelper.Recipes.Api.Persistence.Entities;

namespace ShoppingHelper.Recipes.Api.Persistence.Contexts;

public class RecipeContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Allergen> Allergens { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Yield> Yields { get; set; }
}
