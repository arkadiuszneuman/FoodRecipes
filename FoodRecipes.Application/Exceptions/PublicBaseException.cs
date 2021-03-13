#nullable enable
using System;
using System.Runtime.Serialization;

namespace FoodRecipes.Application.Exceptions
{
    /// <summary>
    /// This is base exception for all exceptions where we want to show error message to end user
    /// It should be handled by middleware/decorator
    /// </summary>
    public class PublicBaseException : BaseException
    {
        public PublicBaseException()
        {
        }

        protected PublicBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PublicBaseException(string? message) : base(message)
        {
        }

        public PublicBaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}