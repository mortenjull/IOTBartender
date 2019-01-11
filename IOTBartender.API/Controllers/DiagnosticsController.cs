using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Application.Commands.Diagnostic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOTBartender.API.Controllers
{
    [Route("api/diagnostics")]
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        /// <summary>
        /// <see cref="IMediator"/> to use.
        /// </summary>
        private readonly IMediator _mediator;

        public DiagnosticsController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }

        [HttpGet("IsAvailable")]
        public async Task<ActionResult> IsAvailable()
        {
            // Get the status if an machine is available.
            var available = await _mediator.Send(new DiagnosticIsAvailableCommand());

            return new OkObjectResult(new { Status = available });
        }

        [HttpGet("CPU/Lastest")]
        public async Task<ActionResult> Cpu()
        {
            // Get the current time.
            var now = DateTime.UtcNow;

            // Get all diagnostics in the last hour.
            var diagnostics = (await _mediator.Send(new DiagnosticBetweenCommand(now.AddHours(-1), now))).ToList();

            // Group by minutes.
            var result = diagnostics.GroupBy(ed => new
            {
                Time = new DateTime(ed.Time.Year, ed.Time.Month, ed.Time.Day, ed.Time.Hour, ed.Time.Minute, 0, ed.Time.Kind)
            }).Select(e => new
            {
                Time = e.Key.Time,
                Name = e.Key.Time.ToString(),
                Count = e.Average(x => x.Cpu)
            });

            return new OkObjectResult(result);
        }

        [HttpGet("Memory/Lastest")]
        public async Task<ActionResult> Memory()
        {
            // Get the current time.
            var now = DateTime.UtcNow;

            // Get all diagnostics in the last hour.
            var diagnostics = (await _mediator.Send(new DiagnosticBetweenCommand(now.AddHours(-1), now))).ToList();

            // Group by minutes.
            var result = diagnostics.GroupBy(ed => new
            {
                Time = new DateTime(ed.Time.Year, ed.Time.Month, ed.Time.Day, ed.Time.Hour, ed.Time.Minute, 0, ed.Time.Kind)
            }).Select(e => new
            {
                Time = e.Key.Time,
                Name = e.Key.Time.ToString(),
                Count = e.Average(x => x.Memory)
            });

            return new OkObjectResult(result);
        }
    }
}