using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using IOTBartender.Domain.Entititeis;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace IOTBartender.Application.Commands.Background
{
    public class BackgroundOutgoingCommand
        : IRequest<bool>
    { }

    public class BackgroundOutgoingCommandHandler
        : IRequestHandler<BackgroundOutgoingCommand, bool>
    {
        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for interaction with data layer.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Logger for logging.
        /// </summary>
        private readonly ILogger<BackgroundIncomingCommandHanlder> _logger;

        public BackgroundOutgoingCommandHandler(IUnitOfWork unitOfWork, ILogger<BackgroundIncomingCommandHanlder> logger)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(Unit));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(BackgroundOutgoingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Outgoing background service is starting");

            while(!cancellationToken.IsCancellationRequested)
            {
                // Specification for getting all the orders which is submitted but not
                // pending.
                var specification = new ExpSpecification<Domain.Entititeis.Order>(
                    x => x.Events.Last().Type == Domain.Entititeis.OrderEvent.OrderEventType.Submitted);

                // Include recipe, components and fluids.
                specification.Include("Recipe.Components.Fluid");

                // Get orders using specification.
                var orders = await _unitOfWork.Repository.Where(specification, cancellationToken);

                // Wait some time before executing again.

                await Task.Delay(1000);
            }

            _logger.LogInformation($"Outgoing background service is stopping.");

            return true;
        }
    }
}
