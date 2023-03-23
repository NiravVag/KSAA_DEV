using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Queries.GSTOutputLiabilityCodesQueries
{
	public class GetGSTOutputLiabilityCodesByIdQuery : IRequest<Response<GSTOutputLiabilityCodesViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetGSTOutputLiabilityCodesByHandler : IRequestHandler<GetGSTOutputLiabilityCodesByIdQuery, Response<GSTOutputLiabilityCodesViewModel>>
    {
        private readonly IGSTOutputLiabilityCodesService _GSTOutputLiabilityCodesService;
        private readonly IMapper _mapper;

        public GetGSTOutputLiabilityCodesByHandler(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService, IMapper mapper)
        {
            _GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
            _mapper = mapper;
        }
        public async Task<Response<GSTOutputLiabilityCodesViewModel>> Handle(GetGSTOutputLiabilityCodesByIdQuery request, CancellationToken cancellationToken)
        {
            var geGSTOutputLiabilityCodesById = await _GSTOutputLiabilityCodesService.GetGSTOutputLiabilityCodesById(request.Id);
            return new Response<GSTOutputLiabilityCodesViewModel>(geGSTOutputLiabilityCodesById);
        }
    }

}