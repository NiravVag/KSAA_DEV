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
    public class CreateGLIncome_MappingCommand : IRequest<Response>
    {
        [Required]
        public virtual string? GLIncomeCode { get; set; }
        [Required]
        public virtual string? GLIncomeDescription { get; set; }
       
        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/
    }

    public class CreateGLIncome_MappingCommandHandler : IRequestHandler<CreateGLIncome_MappingCommand, Response>
    {
        private readonly IGLIncome_MappingService _GLIncome_MappingService;
        public CreateGLIncome_MappingCommandHandler(IGLIncome_MappingService GLIncome_MappingService)
        {
            _GLIncome_MappingService = GLIncome_MappingService;
        }
        public async Task<Response> Handle(CreateGLIncome_MappingCommand request, CancellationToken cancellationToken)
        {

            var documentObject = await _GLIncome_MappingService.AddGLIncome_Mapping(request);
            return new Response("GL Income Mapping Add Successfully");
        }
    }
}