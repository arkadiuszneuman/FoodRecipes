using System.Threading;
using System.Threading.Tasks;
using FoodRecipes.Application.Mappers;
using FoodRecipes.Infrastructure.Repositories;
using MediatR;

namespace FoodRecipes.Application.Queries.Handlers
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, GetRecipeQueryResult>
    {
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeByIdQueryHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<GetRecipeQueryResult> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(request.Id);
            return recipe.MapToGetRecipeQueryResult();
        }
    }
}