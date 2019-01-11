using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Diagnostic
{
    public class DiagnosticBetweenCommand
        : IRequest<IReadOnlyCollection<Domain.Entititeis.Diagnostic>>
    {
        public DiagnosticBetweenCommand(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Start.
        /// </summary>
        public DateTime Start { get; set;  }

        /// <summary>
        /// End.
        /// </summary>
        public DateTime End { get; set; }
    }

    public class DiagnosticBetweenCommandHandler
        : IRequestHandler<DiagnosticBetweenCommand, IReadOnlyCollection<Domain.Entititeis.Diagnostic>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticBetweenCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<Domain.Entititeis.Diagnostic>> Handle(
            DiagnosticBetweenCommand request, CancellationToken cancellationToken)
        {
            var specification = new ExpSpecification<Domain.Entititeis.Diagnostic>(
                x => x.Time >= request.Start && x.Time <= request.End);

            var diagnostics = await _unitOfWork.Repository.Where(specification, cancellationToken);

            return diagnostics;
        }
    }
}
