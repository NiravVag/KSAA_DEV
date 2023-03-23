using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.FunctionCommand
{
    public class DeleteFunctionCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteFunctionCommandHandler : IRequestHandler<DeleteFunctionCommand>
    {
        private readonly IFunctionService _functionService;
        public DeleteFunctionCommandHandler(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<Unit> Handle(DeleteFunctionCommand request, CancellationToken cancellationToken)
        {
            await _functionService.DeleteFunction(request);
            return Unit.Value;
        }
    }
}