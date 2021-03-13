using System;
using System.Collections.Generic;
using MediatR;

namespace FoodRecipes.Application.Queries
{
    public class GetRecipesQueryResult
    {
        public Guid Id { get; init; }
        public string RecipeName { get; init; }
        public string Country { get; init; }
    }

    public class GetRecipesQuery : IRequest<IEnumerable<GetRecipesQueryResult>>
    {
        public int Page { get; init; } = 1;
        public int ItemsPerPage { get; init; } = 10;
    }
}