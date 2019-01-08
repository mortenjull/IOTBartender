using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IOTBartender.API.Models.Entities;
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
        /// <summary>
        /// <see cref="IMediator"/> to use.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// <see cref="IMapper"/> to use.
        /// </summary>
        private readonly IMapper _mapper;

        public RecipiesController(IMediator mediator, IMapper mapper)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var recipe = await _mediator.Send(new RecipeGetCommand(id));

            if (recipe == null)
                return new NotFoundResult();

            var result = _mapper.Map<RecipeModel>(recipe);

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get's all the availalbe recipies in the application.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> All()
        {
            // Get all recipies.
            var recipies = (await _mediator.Send(new RecipeAllCommand())).ToList();

            // Map from recipies entity to model.
            var result = _mapper.Map<List<RecipeModel>>(recipies);

            return new OkObjectResult(result);
        }
    }
}