using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Application.Commands.Recipe;
using IOTBartender.Domain.Entititeis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipiesController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }
        
        /// <summary>
        /// Get's all the availalbe recipies in the application.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> All()
        {
            // Get all recipies.
            var recipies = await _mediator.Send(new RecipeAllCommand());

            return new OkObjectResult(recipies);
        }
    }
}