using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FoodRecipes.Application.Mappers;
using FoodRecipes.Infrastructure.Repositories;
using MediatR;

namespace FoodRecipes.Application.Queries.Handlers
{
    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, IEnumerable<GetRecipesQueryResult>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipesQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        
        public async Task<IEnumerable<GetRecipesQueryResult>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipesAsync(request.Page, request.ItemsPerPage);
            return recipes.MapToGetRecipesQueryResult();
        }
    }
}