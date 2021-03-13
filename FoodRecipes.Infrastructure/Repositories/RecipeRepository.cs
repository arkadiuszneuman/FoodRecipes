using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodRecipes.Infrastructure.Persistence;
using FoodRecipes.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipes.Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes(int page, int itemsPerPage);
        Task<Recipe> GetRecipeById(Guid id);
        void InsertRecipe(Recipe recipe);
        void DeleteRecipe(Guid recipeId);
        void UpdateRecipe(Recipe recipe);
        void Save();
    }

    /// <summary>
    /// We should create some base repository with standard CRUD operations
    /// </summary>
    public class RecipeRepository : IRecipeRepository
    {
        private FoodRecipesContext _context;

        public RecipeRepository(FoodRecipesContext context)
        {
            _context = context;
        }

        public Task<List<Recipe>> GetRecipes(int page, int itemsPerPage)
        {
            //we can get recipes by EF:
            
            //we can of course add Select to select only that fields that we want to have
            //on our list of recipes (for instance only recipe name)
            
            // return _context.Recipes
            //     .AsNoTracking()
            //     .Include(x => x.Country)
            //     .Skip(page * itemsPerPage).Take(itemsPerPage)
            //     .ToListAsync();
            
            //or by dapper to be a little bit faster
            
            //in case of demo I will return some mocked data

            return Task.FromResult(new List<Recipe>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Country = new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Germany"
                    },
                    Description = "Some quite good banana split",
                    Name = "Banana Split",
                    PublishedDate = DateTimeOffset.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Country = new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Poland"
                    },
                    Description = "I love that recipe",
                    Name = "Fish and chips",
                    PublishedDate = DateTimeOffset.Now
                }
            });
        }

        public Task<Recipe> GetRecipeById(Guid id)
        {
            // return _context.Recipes
            //     .Include(x => x.Country)
            //     .Include(x => x.Steps)
            //     .ThenInclude(x => x.Ingredients)
            //     .ThenInclude(x => x.UnitOfMeasure)
            //     .SingleOrDefaultAsync(x => x.Id == id);
            
            //we can also do the same with dapper
            
            //or in case of performance issues, we can create projection table (read model) and get everything from it
            
            //in case of demo I will return some mocked data
            return Task.FromResult(new Recipe
            {
                Id = Guid.NewGuid(),
                Country = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Germany"
                },
                Description = "Some quite good banana split",
                Name = "Banana Split",
                PublishedDate = DateTimeOffset.Now,
                Steps = new List<RecipientStep>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Order = 0,
                        Description = "Add banana to the ice cream",
                        Ingredients = new List<Ingredient>
                        {
                            new()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Banana",
                                Quantity = 1,
                                UnitOfMeasure = new UnitOfMeasure
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "piece"
                                }
                            },
                            new()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Ice cream",
                                Quantity = 200,
                                UnitOfMeasure = new UnitOfMeasure
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "grams"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Order = 1,
                        Description = "Add cherries while mixing everything",
                        Ingredients = new List<Ingredient>
                        {
                            new()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Cherry",
                                Quantity = 5,
                                UnitOfMeasure = new UnitOfMeasure
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "piece"
                                }
                            }
                        }
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Order = 2,
                        Description = "Done :)"
                    }
                }
            });
        }

        public void InsertRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void DeleteRecipe(Guid recipeId)
        {
            var recipe = _context.Recipes.Find(recipeId);
            _context.Recipes.Remove(recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}