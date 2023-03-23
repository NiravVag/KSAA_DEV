using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand
{
    public class UpdateFunctionModuleCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public long FunctionId { get; set; }
        public string? ModuleName { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

    public class UpdateFunctionModuleCommandHandler : IRequestHandler<UpdateFunctionModuleCommand, Response>
    {
        private readonly IFunctionModuleService _functionModuleService;
        private readonly IMapper _mapper;

        public UpdateFunctionModuleCommandHandler(IFunctionModuleService functionModuleService, IMapper mapper)
        {
            _functionModuleService = functionModuleService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateFunctionModuleCommand request, CancellationToken cancellationToken)
        {
            await _functionModuleService.EditFunctionModule(request);

            return new Response("Function Module Updated Successfully");
        }
    }
}
