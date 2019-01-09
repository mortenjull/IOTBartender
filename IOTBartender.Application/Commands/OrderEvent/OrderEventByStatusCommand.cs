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
    public class OrderEventByStatusCommand
        : IRequest<IReadOnlyCollection<Domain.Entititeis.OrderEvent>>
    {
        public OrderEventByStatusCommand(int status)
        {
            Status = status;
        }

        /// <summary>
        /// Status type of events to get.
        /// </summary>
        public int Status { get; set; }
    }

    public class OrderEventByStatusCommandHandler
        : IRequestHandler<OrderEventByStatusCommand, IReadOnlyCollection<Domain.Entititeis.OrderEvent>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderEventByStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Entititeis.OrderEvent>> Handle(OrderEventByStatusCommand request, CancellationToken cancellationToken)
        {
            var status = (Domain.Entititeis.OrderEvent.OrderEventType)request.Status;

            var specification = new ExpSpecification<Domain.Entititeis.OrderEvent>(
                x => x.Type == status);

            var events = await _unitOfWork.Repository.Where(specification, cancellationToken);

            return events;
        }
    }
}
