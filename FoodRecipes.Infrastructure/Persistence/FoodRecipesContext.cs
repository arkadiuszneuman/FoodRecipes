using System.Configuration;
using FoodRecipes.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.Infrastructure.Persistence
{
    public class FoodRecipesContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<RecipientStep> RecipientSteps { get; set; }

        public FoodRecipesContext(DbContextOptions<FoodRecipesContext> contextOptions) : base(contextOptions)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FoodRecipesDatabase"].ConnectionString);
        }
    }
}