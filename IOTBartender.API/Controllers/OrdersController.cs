using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IOTBartender.API.Models.Entities;
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

        /// <summary>
        /// <see cref="IMapper"/> to use.
        /// </summary>
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
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
            var order = await _mediator.Send(new OrderGetCommand(id));

            if (order == null)
                return new NotFoundResult();

            var result = _mapper.Map<OrderModel>(order);

            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] int recipeId)
        {
            // Create order.
            var result = await _mediator.Send(new OrderAddCommand(recipeId));

            // Response with order id.
            return new CreatedAtActionResult("Get", "Orders", new { Id = result }, new { });        
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            // Get all oders.
            var orders = (await _mediator.Send(new OrderAllCommand())).ToList();

            // Map entities to models.
            var result = _mapper.Map<List<OrderModel>>(orders);

            return new OkObjectResult(result);
        }
    }
}