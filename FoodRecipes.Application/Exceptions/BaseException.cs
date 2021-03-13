#nullable enable
using System;
using System.Net;
using System.Runtime.Serialization;

namespace FoodRecipes.Application.Exceptions
{
    //Base exception for all exceptions in Food Recipes app
    public class BaseException : Exception
    {
        /// <summary>
        /// We can handle that in some middleware/decorator and return that status code in REST.
        /// User shouldn't have error message in the response (we should only log error message)
        /// </summary>
        public virtual HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
        
        public BaseException()
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BaseException(string? message) : base(message)
        {
        }

        public BaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}