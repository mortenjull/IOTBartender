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
    public class DiagnosticIsAvailableCommand
        : IRequest<bool>
    {
        public DiagnosticIsAvailableCommand()
        { }
    }

    public class DiagnosticIsAvailableCommandHandler
        : IRequestHandler<DiagnosticIsAvailableCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticIsAvailableCommandHandler(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DiagnosticIsAvailableCommand request, CancellationToken cancellationToken)
        {
            // Get the first diagnostic, if it were created in the last 20 seconds.
            var specification = new ExpSpecification<Domain.Entititeis.Diagnostic>(
                x => x.Time > DateTime.UtcNow.AddSeconds(-20));

            // diagnositc object, if available or null.
            var diagnostic = await _unitOfWork.Repository.FirstOrDefault(specification, cancellationToken);

            return diagnostic != null;
        }
    }
}
