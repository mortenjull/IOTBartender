using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IOTBartender.API.Models.Entities;
using IOTBartender.Application.Commands.OrderEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartender.API.Controllers
{
    [Route("api/orders/events")]
    [ApiController]
    public class OrderEventsController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/> to use.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// <see cref="IMapper"/> to use.
        /// </summary>
        private readonly IMapper _mapper;

        public OrderEventsController(IMediator mediator, IMapper mapper)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult> Status(int status)
        {
            // List of events with the given status.
            var events = (await _mediator.Send(new OrderEventByStatusCommand(status))).ToList();

            // Map order event entity to model.
            var result = _mapper.Map<List<OrderEventModel>>(events);

            return new OkObjectResult(result);
        }

        [HttpGet("status/{status}/lastest")]
        public async Task<ActionResult> StatusLastest(int status)
        {
            // Get the current time.
            var now = DateTime.UtcNow;
            
            var start = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Kind);
            var end = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Kind).AddHours(1);

            // List of events with the given status.
            var events = (await _mediator.Send(new OrderEventByStatusBetweenCommand(status, start, end))).ToList();

            // Group by minutes.
            var result = events.GroupBy(ed => new
            {
                Time = new DateTime(ed.Time.Year, ed.Time.Month, ed.Time.Day, ed.Time.Hour, ed.Time.Minute, 0, ed.Time.Kind)
            }).Select(e => new
            {
                Time = e.Key.Time,
                Name = e.Key.Time.ToString(),
                Count = e.Count()
            });

            return new OkObjectResult(result);
        }
    }
}