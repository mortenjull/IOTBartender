using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Recipe
{
    public class RecipeAllCommand
        : IRequest<IReadOnlyCollection<IOTBartender.Domain.Entititeis.Recipe>>
    {
        public RecipeAllCommand() { }
    }

    public class RecipeAllCommandHandler
        : IRequestHandler<RecipeAllCommand, IReadOnlyCollection<IOTBartender.Domain.Entititeis.Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeAllCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Entititeis.Recipe>> Handle(RecipeAllCommand request, CancellationToken cancellationToken)
        {
            // Specification for recipe.
            var specification = new Specification<Domain.Entititeis.Recipe>();

            specification.Include(x => x.Components);
            specification.Include(x => x.Orders);

            // Get all the recipies in the application.
            var recipies = await _unitOfWork
                .Repository
                .All(specification, cancellationToken);

            return recipies;
        }
    }
}
