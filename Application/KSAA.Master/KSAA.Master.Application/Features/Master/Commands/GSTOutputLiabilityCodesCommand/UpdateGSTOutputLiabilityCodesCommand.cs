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

namespace KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand
{
	public class UpdateGSTOutputLiabilityCodesCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? CustomerCode { get; set; }
        public string? GLLiabilityName { get; set; }
        public string? GLLiabilityCode { get; set; }
        //public string? Upload { get; set; }
        public string? LedgerMapping { get; set; }
        public IsActive IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UpdateGSTOutputLiabilityCodesCommandHandler : IRequestHandler<UpdateGSTOutputLiabilityCodesCommand, Response>
    {
        private readonly IGSTOutputLiabilityCodesService _GSTOutputLiabilityCodesService;
        private readonly IMapper _mapper;

        public UpdateGSTOutputLiabilityCodesCommandHandler(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService, IMapper mapper)
        {
            _GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateGSTOutputLiabilityCodesCommand request, CancellationToken cancellationToken)
        {
            await _GSTOutputLiabilityCodesService.EditGSTOutputLiabilityCodes(request);

            return new Response("GL Liability Code Updated Successfully");
        }
    }
}