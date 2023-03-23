using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand
{
    public class DeleteGLIncome_MappingCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteGLIncome_MappingCommandHandler : IRequestHandler<DeleteGLIncome_MappingCommand>
    {
        private readonly IGLIncome_MappingService _GLIncome_MappingService;
        public DeleteGLIncome_MappingCommandHandler(IGLIncome_MappingService GLIncome_MappingService)
        {
            _GLIncome_MappingService = GLIncome_MappingService;
        }

        public async Task<Unit> Handle(DeleteGLIncome_MappingCommand request, CancellationToken cancellationToken)
        {
            await _GLIncome_MappingService.DeleteGLIncome_Mapping(request);
            return Unit.Value;

        }
    }
}