using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FoodRecipes.Application.Queries.Handlers
{
    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, GetRecipesQueryResult>
    {
        public async Task<GetRecipesQueryResult> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            return new GetRecipesQueryResult();
        }
    }
}