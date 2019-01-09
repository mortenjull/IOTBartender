using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Order
{
    public class OrderAllCommand
        : IRequest<IReadOnlyCollection<IOTBartender.Domain.Entititeis.Order>>
    {
        public OrderAllCommand() { }
    }

    public class OrderAllCommandHandler
        : IRequestHandler<OrderAllCommand, IReadOnlyCollection<IOTBartender.Domain.Entititeis.Order>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderAllCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Entititeis.Order>> Handle(OrderAllCommand request, CancellationToken cancellationToken)
        {
            var specification = new Specification<Domain.Entititeis.Order>();

            specification.Include("Events");

            // Get all orders from repository.
            var orders = await _unitOfWork
                .Repository
                .All(specification, cancellationToken);

            return orders;
        }
    }
}
