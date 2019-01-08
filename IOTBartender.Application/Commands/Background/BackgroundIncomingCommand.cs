using IOTBartender.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Background
{
    public class BackgroundIncomingCommand
        : IRequest<bool>
    { }

    public class BackgroundIncomingCommandHanlder
        : IRequestHandler<BackgroundIncomingCommand, bool>
    {
        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for interaction with data layer.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Logger for logging.
        /// </summary>
        private readonly ILogger<BackgroundIncomingCommandHanlder> _logger;

        public BackgroundIncomingCommandHanlder(IUnitOfWork unitOfWork, ILogger<BackgroundIncomingCommandHanlder> logger)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(Unit));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(BackgroundIncomingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Incoming background service is starting");



            _logger.LogInformation($"Incoming background service is stopping.");

            return true;
        }
    }
}
