using MediatR;

namespace FoodRecipes.Application.Queries
{
    public class GetRecipesQueryResult
    {
        public string Products { get; set; } = "products";
    }

    public class GetRecipesQuery : IRequest<GetRecipesQueryResult>
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
    }
}