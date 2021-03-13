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
                Country = x.Country.Name,
                PublishedDate = x.PublishedDate
            });

        public static GetRecipeQueryResult MapToGetRecipeQueryResult(this Recipe recipe)
        {
            var dto = new GetRecipeQueryResult
            {
                Id = recipe.Id,
                Country = recipe.Country.Name,
                RecipeName = recipe.Name,
                PublishedDate = recipe.PublishedDate,
                Description = recipe.Description,
                Steps = recipe.Steps.MapToGetRecipeQueryStepResult().OrderBy(x => x.Order).ToList(),
            };

            dto.AllIngredients = dto.Steps.SelectMany(x => x.Ingredients).ToList();

            return dto;
        }

        private static IEnumerable<GetRecipeQueryResult.GetRecipeQueryStepResult> MapToGetRecipeQueryStepResult(
            this IEnumerable<RecipientStep> steps) =>
            steps.Select(x => new GetRecipeQueryResult.GetRecipeQueryStepResult
                {
                    Id = x.Id,
                    Description = x.Description,
                    Order = x.Order,
                    Ingredients = x.Ingredients?.MapToGetRecipeQueryStepResult()?.ToList() ?? new List<GetRecipeQueryResult.GetRecipeQueryIngredient>()
                });
        
        private static IEnumerable<GetRecipeQueryResult.GetRecipeQueryIngredient> MapToGetRecipeQueryStepResult(
            this IEnumerable<Ingredient> steps) =>
            steps.Select(x => new GetRecipeQueryResult.GetRecipeQueryIngredient
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                UnitOfMeasure = x.UnitOfMeasure.Name
            });
    }
}