using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand
{
	public class CreateAdvanceMappingCommand : IRequest<Response>
    {
        [Required]
        public virtual string? CustomerCode { get; set; }
        [Required]
        public virtual string? AdvanceMappingCode { get; set; }
        [Required]
        public virtual string? GLAdvanceName { get; set; }
        [Required]
        public virtual string? GLAdvanceCode { get; set; }
        //[Required]
        //public virtual string? Upload { get; set; }
        [Required]
        public virtual string? LedgerMapping { get; set; }

        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/
    }

    public class CreateAdvance_MappingCommandHandler : IRequestHandler<CreateAdvanceMappingCommand, Response>
    {
        private readonly IAdvanceMappingService _AdvanceMapping;
        public CreateAdvance_MappingCommandHandler(IAdvanceMappingService AdvanceMapping)
        {
            _AdvanceMapping = AdvanceMapping;
        }
        public async Task<Response> Handle(CreateAdvanceMappingCommand request, CancellationToken cancellationToken)
        {
            var documentObject = await _AdvanceMapping.AddAdvanceMapping(request);
            return new Response("Advance Mapping Add Successfully");
        }
    }
}
