using FoodRecipes.Application.Commands;
using FoodRecipes.Infrastructure.Persistence.Models;

namespace FoodRecipes.Application.Mappers
{
    public static class UpdateRecipeMappers
    {
        public static void MapToRecipe(this UpdateRecipe updateRecipe, Recipe recipe)
        {
            recipe.Name = updateRecipe.RecipeName;
            recipe.Description = updateRecipe.Description;
            //map here other properties
        }
    }
}