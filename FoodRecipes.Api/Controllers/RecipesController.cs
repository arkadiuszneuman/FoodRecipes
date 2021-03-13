using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FoodRecipes.Application.Commands;
using FoodRecipes.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IEnumerable<GetRecipesQueryResult>> Get([FromQuery] GetRecipesQuery query, CancellationToken cancellationToken) =>
            _mediator.Send(query, cancellationToken);

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<GetRecipeQueryResult> GetById(Guid id, CancellationToken cancellationToken) =>
            _mediator.Send(new GetRecipeByIdQuery(id), cancellationToken);

        [HttpPost]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //we can have roles to each endpoint
        // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateRecipe(Guid id, [FromBody] UpdateRecipe updateRecipe, CancellationToken cancellationToken)
        {
            var updateRecipeCommand = updateRecipe with {Id = id};
            var result = await _mediator.Send(updateRecipeCommand, cancellationToken);
            return new StatusCodeResult((int)result.StatusCode);     
        }
    }
}