using System;
using System.Threading.Tasks;
using FluentAssertions;
using FoodRecipes.Application.Commands;
using FoodRecipes.Application.Commands.Handlers;
using FoodRecipes.Application.Exceptions;
using FoodRecipes.Infrastructure.Persistence.Models;
using FoodRecipes.Infrastructure.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace FoodRecipes.UnitTests.Commands.Handlers
{
    public class UpdateRecipeHandlerTests : BaseUnitTest<UpdateRecipeHandler>
    {
        [Test]
        public async Task Handle_RecipeDoesNotNotExists_ExceptionThrown()
        {
            var id = Guid.NewGuid();
            Mock<IRecipeRepository>()
                .GetRecipeByIdAsync(id)
                .Returns((Recipe)null);

            Func<Task> result = () => Sut.Handle(new UpdateRecipe() {Id = id}, default);

            await result.Should().ThrowExactlyAsync<RecipeDoesNotExistException>();
        }
        
        //TODO other test, which will check if if the old recipe is archived and if new recipe maps properly
    }
}