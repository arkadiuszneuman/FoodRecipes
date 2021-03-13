using System;
using System.Collections.Generic;

namespace FoodRecipes.Infrastructure.Persistence.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public DateTimeOffset PublishedDate { get; set; }
        public List<RecipientStep> Steps { get; set; }
    }
}