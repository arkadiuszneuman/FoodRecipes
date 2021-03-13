using System.Collections.Generic;
using System.Linq;
using FoodRecipes.Application.Queries;
using FoodRecipes.Infrastructure.Persistence.Models;

namespace FoodRecipes.Application.Mappers
{
    public static class RecipeMappers
    {
        public static IEnumerable<GetRecipesQueryResult> MapToGetRecipesQueryResult(this IEnumerable<Recipe> recipes) =>
            recipes.Select(x => new GetRecipesQueryResult
            {
                Id = x.Id,
                RecipeName = x.Name,
                Country = x.Country.Name
            });
    }
}