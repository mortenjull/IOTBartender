using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Application.Commands.Recipe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartender.API.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }
        
        /// <summary>
        /// Get's all the availalbe recipies in the application.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            // Get all recipies.
            var recipies = await _mediator.Send(new RecipeAllCommand());

            return new OkObjectResult(recipies);
        }
    }
}