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

namespace KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand
{
	public class UpdateAdvanceMappingCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? CustomerCode { get; set; }
        public string? AdvanceMappingCode { get; set; }
        public string? GLAdvanceName { get; set; }
        public string? GLAdvanceCode { get; set; }
        //public string? Upload { get; set; }
        public string? LedgerMapping { get; set; }
        public IsActive IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UpdateAdvance_MappingCommandHandler : IRequestHandler<UpdateAdvanceMappingCommand, Response>
    {
        private readonly IAdvanceMappingService _AdvanceMappingService;
        private readonly IMapper _mapper;

        public UpdateAdvance_MappingCommandHandler(IAdvanceMappingService AdvanceMappingService, IMapper mapper)
        {
            _AdvanceMappingService = AdvanceMappingService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateAdvanceMappingCommand request, CancellationToken cancellationToken)
        {
            await _AdvanceMappingService.EditAdvanceMapping(request);

            return new Response("Advance Mapping Updated Successfully");
        }
    }
}
