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

namespace KSAA.Master.Application.Features.Master.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<Response<LocationViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Response<LocationViewModel>>
    {
        private readonly ILocationService _LocationService;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(ILocationService LocationService, IMapper mapper)
        {
            _LocationService = LocationService;
            _mapper = mapper;
        }
        public async Task<Response<LocationViewModel>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var geLocationById = await _LocationService.GetLocationById(request.Id);
            return new Response<LocationViewModel>(geLocationById);
        }
    }
}

