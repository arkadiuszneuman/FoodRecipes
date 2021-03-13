using System.Threading;
using System.Threading.Tasks;
using FoodRecipes.Application.Exceptions;
using FoodRecipes.Application.Mappers;
using FoodRecipes.Infrastructure.Repositories;
using MediatR;

namespace FoodRecipes.Application.Commands.Handlers
{
    public class UpdateRecipeHandler : AsyncRequestHandler<UpdateRecipe>
    {
        private readonly IRecipeRepository _recipeRepository;

        public UpdateRecipeHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        protected override async Task Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeById(request.Id);
            if (recipe == null)
                throw new RecipeDoesNotExistException(request.Id);
            
            request.MapToRecipe(recipe);
            
            _recipeRepository.UpdateRecipe(recipe);
            _recipeRepository.Save();
        }
    }
}