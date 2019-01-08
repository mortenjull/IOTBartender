using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Application.Commands.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartender.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/> to use.
        /// </summary>
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return new OkResult();
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] int recipeId)
        {
            // Create order.
            var result = await _mediator.Send(new OrderAddCommand(recipeId));

            // Response with order id.
            return new CreatedAtActionResult("Get", "Orders", new { Id = result }, new { });        
        }
    }
}