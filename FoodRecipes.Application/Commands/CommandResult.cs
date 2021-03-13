using System.Net;
using Newtonsoft.Json;

namespace FoodRecipes.Application.Commands
{
    public interface ICommandResult
    {
        HttpStatusCode StatusCode { get; init; }
        object Data { get; init; }
    }

    public class CommandResult : ICommandResult
    {
        [JsonIgnore] public HttpStatusCode StatusCode { get; init; }
        public object Data { get; init; }

        private CommandResult()
        {
        }

        public static CommandResult Ok => new CommandResult {StatusCode = HttpStatusCode.OK};
        public static CommandResult Created(object data) => new CommandResult
        {
            StatusCode = HttpStatusCode.Created,
            Data = data
        };
    }
}