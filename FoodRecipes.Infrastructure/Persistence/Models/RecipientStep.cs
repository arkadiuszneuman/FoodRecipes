using System;

namespace FoodRecipes.Infrastructure.Persistence.Models
{
    public class RecipientStep
    {
        public Guid Id { get; set; }
        /// <summary>
        /// We have to order our steps to know which step will be next. I suppose that number of steps won't be quite big
        /// (in case of byte, it must be lower than 256)
        /// </summary>
        public byte Order { get; set; }
    }
}