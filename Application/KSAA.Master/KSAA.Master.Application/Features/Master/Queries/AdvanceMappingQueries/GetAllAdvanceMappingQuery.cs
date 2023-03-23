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

namespace KSAA.Master.Application.Features.Master.Queries.AdvanceMappingQueries
{
	public class GetAllAdvanceMappingQuery : IRequest<Response<IEnumerable<AdvanceMappingListModel>>>
    {
    }

    public class GetAllAdvanceMappingQueryHandler : IRequestHandler<GetAllAdvanceMappingQuery, Response<IEnumerable<AdvanceMappingListModel>>>
    {
        private readonly IAdvanceMappingService _AdvanceMappingService;
        private readonly IMapper _mapper;

        public GetAllAdvanceMappingQueryHandler(IAdvanceMappingService AdvanceMappingService, IMapper mapper)
        {
            _AdvanceMappingService = AdvanceMappingService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<AdvanceMappingListModel>>> Handle(GetAllAdvanceMappingQuery request, CancellationToken cancellationToken)
        {
            var AdvanceMappingList = await _AdvanceMappingService.GetAdvanceMappingList();

            return new Response<IEnumerable<AdvanceMappingListModel>>(AdvanceMappingList);
        }
    }
}
