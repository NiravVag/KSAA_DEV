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

namespace KSAA.Master.Application.Features.Master.Queries.PlantCodeQueries
{
    public class GetPlantCodeByIdQuery : IRequest<Response<PlantCodeViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetPlantCodeByIdQueryHandler : IRequestHandler<GetPlantCodeByIdQuery, Response<PlantCodeViewModel>>
    {
        private readonly IPlantCodeService _PlantCodeService;
        private readonly IMapper _mapper;

        public GetPlantCodeByIdQueryHandler(IPlantCodeService PlantCodeService, IMapper mapper)
        {
            _PlantCodeService = PlantCodeService;
            _mapper = mapper;
        }
        public async Task<Response<PlantCodeViewModel>> Handle(GetPlantCodeByIdQuery request, CancellationToken cancellationToken)
        {
            var gePlantCodeById = await _PlantCodeService.GetPlantCodeById(request.Id);
            return new Response<PlantCodeViewModel>(gePlantCodeById);
        }
    }
}
