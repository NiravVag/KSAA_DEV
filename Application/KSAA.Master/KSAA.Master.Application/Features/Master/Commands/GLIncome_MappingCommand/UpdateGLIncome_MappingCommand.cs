using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand
{
    public class UpdateGLIncome_MappingCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? GLIncomeCode { get; set; }
        public string? GLIncomeDescription { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public IsActive IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UpdateGLIncome_MappingCommandHandler : IRequestHandler<UpdateGLIncome_MappingCommand, Response>
    {
        private readonly IGLIncome_MappingService _GLIncome_MappingService;
        private readonly IMapper _mapper;

        public UpdateGLIncome_MappingCommandHandler(IGLIncome_MappingService GLIncome_MappingService, IMapper mapper)
        {
            _GLIncome_MappingService = GLIncome_MappingService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateGLIncome_MappingCommand request, CancellationToken cancellationToken)
        {
            await _GLIncome_MappingService.EditGLIncome_Mapping(request);

            return new Response("GL Income Mapping Updated Successfully");
        }
    }
}
