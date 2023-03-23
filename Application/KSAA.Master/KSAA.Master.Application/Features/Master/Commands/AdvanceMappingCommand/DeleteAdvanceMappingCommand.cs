using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand
{
	public class DeleteAdvanceMappingCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteAdvance_MappingCommandHandler : IRequestHandler<DeleteAdvanceMappingCommand>
    {
        private readonly IAdvanceMappingService _AdvanceMappingService;
        public DeleteAdvance_MappingCommandHandler(IAdvanceMappingService Advance_MappingService)
        {
            _AdvanceMappingService = Advance_MappingService;
        }

        public async Task<Unit> Handle(DeleteAdvanceMappingCommand request, CancellationToken cancellationToken)
        {
            await _AdvanceMappingService.DeleteAdvanceMapping(request);
            return Unit.Value;

        }
    }
}
