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
    public class OrderGetCommand
        : IRequest<Domain.Entititeis.Order>
    {
        public OrderGetCommand(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Id of the order to get.
        /// </summary>
        public int Id { get; set; }
    }

    public class OrderGetCommandHandler
        : IRequestHandler<OrderGetCommand, Domain.Entititeis.Order>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderGetCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entititeis.Order> Handle(OrderGetCommand request, CancellationToken cancellationToken)
        {
            var specification = new ExpSpecification<Domain.Entititeis.Order>(
                x => x.Id == request.Id);

            var order = await _unitOfWork.Repository.FirstOrDefault(specification, cancellationToken);

            return order;
        }
    }
}
