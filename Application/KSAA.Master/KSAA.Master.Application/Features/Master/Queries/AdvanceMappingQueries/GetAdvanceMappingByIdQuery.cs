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

namespace KSAA.Master.Application.Features.Master.Queries.AdvanceMappingQueries
{
	public class GetAdvanceMappingByIdQuery : IRequest<Response<AdvanceMappingViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetAdvanceMappingByHandler : IRequestHandler<GetAdvanceMappingByIdQuery, Response<AdvanceMappingViewModel>>
    {
        private readonly IAdvanceMappingService _AdvanceMappingService;
        private readonly IMapper _mapper;

        public GetAdvanceMappingByHandler(IAdvanceMappingService AdvanceMappingService, IMapper mapper)
        {
            _AdvanceMappingService = AdvanceMappingService;
            _mapper = mapper;
        }
        public async Task<Response<AdvanceMappingViewModel>> Handle(GetAdvanceMappingByIdQuery request, CancellationToken cancellationToken)
        {
            var geAdvanceMappingById = await _AdvanceMappingService.GetAdvanceMappingById(request.Id);
            return new Response<AdvanceMappingViewModel>(geAdvanceMappingById);
        }
    }

}
