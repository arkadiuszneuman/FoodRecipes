using FoodRecipes.Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Api.CompositionRoots
{
    public static class ApplicationCompositionRoot
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetRecipesQuery));

            return services;
        }
    }
}