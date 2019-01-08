using IOTBartender.Domain.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Order
{
    public class OrderAddCommand
        : IRequest<int>
    {
        public OrderAddCommand(int recipeId)
        {
            RecipeId = recipeId;
        }

        /// <summary>
        /// Id of the <see cref="Recipe"/> in the order.
        /// </summary>
        public int RecipeId { get; set; }
    }

    public class OrderAddCommandHandler
        : IRequestHandler<OrderAddCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderAddCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entititeis.Order()
            {
                RecipeId = request.RecipeId
            };

            // Add order to repository.
            order = _unitOfWork.Repository.Add(order);

            // Save all changes.
            var result = await _unitOfWork.SaveChanges(cancellationToken);

            return order.Id;
        }
    }
}
