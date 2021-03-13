using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FoodRecipes.Application.Exceptions;
using FoodRecipes.Application.Mappers;
using FoodRecipes.Infrastructure.Persistence.Models;
using FoodRecipes.Infrastructure.Repositories;
using MediatR;

namespace FoodRecipes.Application.Commands.Handlers
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipe, ICommandResult>
    {
        private readonly IRecipeRepository _recipeRepository;

        public UpdateRecipeHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ICommandResult> Handle(UpdateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(request.Id);
            if (recipe == null)
                throw new RecipeDoesNotExistException(request.Id);

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await ArchiveOldRecipeAsync(recipe);
            
            request.MapToRecipe(recipe);
            
            _recipeRepository.UpdateRecipe(recipe);
            await _recipeRepository.SaveAsync();
            
            scope.Complete();
            
            return CommandResult.Ok;
        }

        /// <summary>
        /// This method create copy of recipe in the database for history
        /// We can use EventStorming to save only events, then we will have full history
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        private async Task ArchiveOldRecipeAsync(Recipe recipe)
        {
            //we should duplicate recipe and it's steps here
            //I did some temporary hax to save id and then restore it
            var oldId = recipe.Id;
            
            recipe.IsArchived = true;
            recipe.ArchiveDate = DateTimeOffset.Now;
            recipe.Id = Guid.NewGuid();

            await _recipeRepository.InsertRecipeAsync(recipe);
            await _recipeRepository.SaveAsync();

            recipe.Id = oldId;
        }
    }
}