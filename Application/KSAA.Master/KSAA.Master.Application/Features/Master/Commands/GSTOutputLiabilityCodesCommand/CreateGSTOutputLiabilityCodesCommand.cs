using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand
{
	public class CreateGSTOutputLiabilityCodesCommand : IRequest<Response>
    {
        [Required]
        public virtual string? CustomerCode { get; set; }
        [Required]
        public virtual string? GLLiabilityName { get; set; }
        [Required]
        public virtual string? GLLiabilityCode { get; set; }
        //[Required]
        //public virtual string? Upload { get; set; }
        [Required]
        public virtual string? LedgerMapping { get; set; }

        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/
    }

    public class CreateGSTOutputLiabilityCodesCommandHandler : IRequestHandler<CreateGSTOutputLiabilityCodesCommand, Response>
    {
        private readonly IGSTOutputLiabilityCodesService _GSTOutputLiabilityCodesService;
        public CreateGSTOutputLiabilityCodesCommandHandler(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService)
        {
            _GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
        }
        public async Task<Response> Handle(CreateGSTOutputLiabilityCodesCommand request, CancellationToken cancellationToken)
        {
            var documentObject = await _GSTOutputLiabilityCodesService.AddGSTOutputLiabilityCodes(request);
            return new Response("GST Output Liability Codes Add Successfully");
        }
    }
}
