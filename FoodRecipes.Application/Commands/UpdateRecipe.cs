using System;
using System.Collections.Generic;
using MediatR;

namespace FoodRecipes.Application.Commands
{
    public record UpdateRecipe : IRequest<ICommandResult>
    {
        public Guid Id { get; init; }
        public string RecipeName { get; init; }
        public string Country { get; init; }
        public DateTimeOffset PublishedDate { get; init; }
        public string Description { get; init; }
        public IReadOnlyList<UpdateRecipeStep> Steps { get; init; }

        public class UpdateRecipeStep
        {
            public Guid Id { get; init; }
            public string Description { get; init; }
            public byte Order { get; init; }
            public IReadOnlyList<UpdateRecipeIngredient> Ingredients { get; init; }
        }

        public class UpdateRecipeIngredient
        {
            public Guid Id { get; init; }
            public string Name { get; init; }
            public decimal Quantity { get; init; }
            public string UnitOfMeasure { get; init; }
        }
    }
}