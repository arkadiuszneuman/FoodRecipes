using FoodRecipes.Infrastructure.Persistence;
using FoodRecipes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipes.Api.CompositionRoots
{
    public static class InfrastructureCompositionRoot
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FoodRecipesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FoodRecipesDatabase")));

            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}