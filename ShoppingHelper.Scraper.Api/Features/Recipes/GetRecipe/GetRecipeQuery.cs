using MediatR;

namespace ShoppingHelper.Scraper.Api.Features.Recipes.GetRecipe;

public record GetRecipeQuery(string RecipeId) : IRequest<GetRecipeResponse>;