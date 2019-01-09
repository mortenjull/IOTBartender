using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.OrderEvent
{
    public class OrderEventByStatusBetweenCommand
        : IRequest<IReadOnlyCollection<Domain.Entititeis.OrderEvent>>
    {
        public OrderEventByStatusBetweenCommand(int status, DateTime start, DateTime end)
        {
            Status = status;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Status type of events to get.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End time.
        /// </summary>
        public DateTime End { get; set; }
    }

    public class OrderEventByStatusBetweenCommandHandler
        : IRequestHandler<OrderEventByStatusBetweenCommand, IReadOnlyCollection<Domain.Entititeis.OrderEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderEventByStatusBetweenCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Entititeis.OrderEvent>> Handle(OrderEventByStatusBetweenCommand request, CancellationToken cancellationToken)
        {
            var status = (Domain.Entititeis.OrderEvent.OrderEventType)request.Status;

            var specification = new ExpSpecification<Domain.Entititeis.OrderEvent>(
                x => x.Type == status && x.Time >= request.Start && x.Time <= request.End);

            var events = await _unitOfWork.Repository.Where(specification, cancellationToken);

            return events;
        }
    }
}
