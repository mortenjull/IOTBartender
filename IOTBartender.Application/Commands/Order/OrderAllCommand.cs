using IOTBartender.Domain.Entititeis;
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
        public Task<IReadOnlyCollection<Domain.Entititeis.Order>> Handle(OrderAllCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
