using System;
using System.Collections.Generic;
using MediatR;

namespace FoodRecipes.Application.Queries
{
    public class GetRecipeQueryResult
    {
        public Guid Id { get; init; }
        public string RecipeName { get; init; }
        public string Country { get; init; }
        public DateTimeOffset PublishedDate { get; init; }
        public string Description { get; init; }
        public IReadOnlyList<GetRecipeQueryIngredient> AllIngredients { get; set; }
        public IReadOnlyList<GetRecipeQueryStepResult> Steps { get; init; }

        public class GetRecipeQueryStepResult
        {
            public Guid Id { get; init; }
            public string Description { get; init; }
            public byte Order { get; init; }
            public IReadOnlyList<GetRecipeQueryIngredient> Ingredients { get; init; }
        }

        public class GetRecipeQueryIngredient
        {
            public Guid Id { get; init; }
            public string Name { get; init; }
            public decimal Quantity { get; init; }
            public string UnitOfMeasure { get; init; }
        }
    }

    public record GetRecipeByIdQuery(Guid Id) : IRequest<GetRecipeQueryResult>;
}