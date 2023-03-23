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

namespace KSAA.Master.Application.Features.Master.Commands.FunctionCommand
{
    public class UpdateFunctionCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? FunctionName { get; set; }
        public string? FunctionCode { get; set; }
        public string? ClientCode { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }

    }
    public class UpdateFunctionCommandHandler : IRequestHandler<UpdateFunctionCommand, Response>
    {
        private readonly IFunctionService _functionService;
        private readonly IMapper _mapper;

        public UpdateFunctionCommandHandler(IFunctionService functionService, IMapper mapper)
        {
            _functionService = functionService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateFunctionCommand request, CancellationToken cancellationToken)
        {
            await _functionService.EditFunction(request);

            return new Response("Function Updated Successfully");
        }
    }
}
