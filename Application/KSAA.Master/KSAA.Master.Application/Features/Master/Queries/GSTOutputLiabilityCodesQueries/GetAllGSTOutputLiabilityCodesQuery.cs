using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
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
	public class GetAllGSTOutputLiabilityCodesQuery : IRequest<Response<IEnumerable<GSTOutputLiabilityCodesListModel>>>
    {
    }

    public class GetAllGSTOutputLiabilityCodesQueryHandler : IRequestHandler<GetAllGSTOutputLiabilityCodesQuery, Response<IEnumerable<GSTOutputLiabilityCodesListModel>>>
    {
        private readonly IGSTOutputLiabilityCodesService _GSTOutputLiabilityCodesService;
        private readonly IMapper _mapper;
        public GetAllGSTOutputLiabilityCodesQueryHandler(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService, IMapper mapper)
        {
            _GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GSTOutputLiabilityCodesListModel>>> Handle(GetAllGSTOutputLiabilityCodesQuery request, CancellationToken cancellationToken)
        {
            var GSTOutputLiabilityCodesList = await _GSTOutputLiabilityCodesService.GetGSTOutputLiabilityCodesList();

            return new Response<IEnumerable<GSTOutputLiabilityCodesListModel>>(GSTOutputLiabilityCodesList);
        }
    }
}