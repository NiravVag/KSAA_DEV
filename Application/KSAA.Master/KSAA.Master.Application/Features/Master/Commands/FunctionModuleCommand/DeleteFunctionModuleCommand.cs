using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand
{
    public class DeleteFunctionModuleCommand : IRequest
    {
        public virtual long Id { get; set; }
    }

    public class DeleteFunctionModuleCommandHandler : IRequestHandler<DeleteFunctionModuleCommand>
    {
        private readonly IFunctionModuleService _functionModuleService;
        public DeleteFunctionModuleCommandHandler(IFunctionModuleService functionModuleService)
        {
            _functionModuleService = functionModuleService;
        }

        public async Task<Unit> Handle(DeleteFunctionModuleCommand request, CancellationToken cancellationToken)
        {
            await _functionModuleService.DeleteFunctionModule(request);
            return Unit.Value;
        }
    }
}
