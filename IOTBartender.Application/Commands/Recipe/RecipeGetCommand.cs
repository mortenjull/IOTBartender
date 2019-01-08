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
    public class RecipeGetCommand
        : IRequest<Domain.Entititeis.Recipe>
    {
        public RecipeGetCommand(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Id of the <see cref="Recipe"/> to get.
        /// </summary>
        public int Id { get; set; }
    }

    public class RecipeGetCommandHandler
        : IRequestHandler<RecipeGetCommand, Domain.Entititeis.Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeGetCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entititeis.Recipe> Handle(RecipeGetCommand request, CancellationToken cancellationToken)
        {
            var specification = new ExpSpecification<Domain.Entititeis.Recipe>(
                x => x.Id == request.Id);

            specification.Include("Components.Fluid");

            var recipe = await _unitOfWork.Repository.FirstOrDefault(specification, cancellationToken);

            return recipe;
        }
    }
}
