using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FoodRecipes.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : Controller
    {
        private readonly IMediator _mediator;

        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<GetRecipesQueryResult>> Get([FromQuery]GetRecipesQuery query, CancellationToken cancellationToken) =>
            _mediator.Send(query, cancellationToken);
    }
}