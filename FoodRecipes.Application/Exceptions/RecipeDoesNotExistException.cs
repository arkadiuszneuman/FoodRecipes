using System;
using System.Net;

namespace FoodRecipes.Application.Exceptions
{
    public class RecipeDoesNotExistException : BaseException
    {
        public Guid RecipeId { get; }
        /// <summary>
        /// In case if recipe does not exist then whe shoud return 404 to end-user
        /// </summary>
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public RecipeDoesNotExistException(Guid recipeId) : base($"Recipe {recipeId} does not exists exception")
        {
            RecipeId = recipeId;
        }
    }
}