using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Features.Master.Queries.DocumetTypeQueries;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Queries.TBTaggingQueries
{
    public class GetTBTaggingByIdQuery : IRequest<Response<TBTaggingViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetTBTaggingByIdQueryHandler : IRequestHandler<GetTBTaggingByIdQuery, Response<TBTaggingViewModel>>
    {
        private readonly ITBTaggingService _TBTaggingService;
        private readonly IMapper _mapper;

        public GetTBTaggingByIdQueryHandler(ITBTaggingService TBTaggingService, IMapper mapper)
        {
            _TBTaggingService = TBTaggingService;
            _mapper = mapper;
        }
        public async Task<Response<TBTaggingViewModel>> Handle(GetTBTaggingByIdQuery request, CancellationToken cancellationToken)
        {
            var geTBTaggingById = await _TBTaggingService.GetTBTaggingById(request.Id);
            return new Response<TBTaggingViewModel>(geTBTaggingById);
        }
    }
}
