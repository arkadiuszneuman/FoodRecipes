using System;

namespace FoodRecipes.Infrastructure.Persistence.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        /// <summary>
        /// I was wondering if to normalize this a little bit more - to move name to separate table, but I eventually decided not to do it right now
        /// (but it can be good to have for table with ingredients names in case of multilanguage app)
        /// </summary>
        public string Name { get; set; }
        public int Quantity { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}