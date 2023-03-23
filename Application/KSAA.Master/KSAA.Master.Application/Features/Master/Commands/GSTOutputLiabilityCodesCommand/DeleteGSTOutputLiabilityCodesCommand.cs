using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand
{
	public class DeleteGSTOutputLiabilityCodesCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteGSTOutputLiabilityCodesCommandHandler : IRequestHandler<DeleteGSTOutputLiabilityCodesCommand>
    {
        private readonly IGSTOutputLiabilityCodesService _GSTOutputLiabilityCodesService;
        public DeleteGSTOutputLiabilityCodesCommandHandler(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService)
        {
            _GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
        }

        public async Task<Unit> Handle(DeleteGSTOutputLiabilityCodesCommand request, CancellationToken cancellationToken)
        {
            await _GSTOutputLiabilityCodesService.DeleteGSTOutputLiabilityCodes(request);
            return Unit.Value;

        }
    }
}