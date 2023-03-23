using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand
{
    public class CreateFunctionModuleCommand : IRequest<Response>
    {
        [Required]
        public long FunctionId { get; set; }
        [Required]
        public string? ModuleName { get; set; }
    }

    public class CreateFunctionModuleHandler : IRequestHandler<CreateFunctionModuleCommand, Response>
    {
        private readonly IFunctionModuleService _functionModuleService;
        public CreateFunctionModuleHandler(IFunctionModuleService functionModuleService)
        {
            _functionModuleService = functionModuleService;
        }
        public async Task<Response> Handle(CreateFunctionModuleCommand request, CancellationToken cancellationToken)
        {
            var documentObject = await _functionModuleService.AddFunctionModule(request);
            return new Response("Function Module Add Successfully");
        }
    }
}
