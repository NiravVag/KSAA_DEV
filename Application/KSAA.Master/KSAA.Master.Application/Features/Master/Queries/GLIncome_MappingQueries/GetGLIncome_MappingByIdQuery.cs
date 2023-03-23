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

namespace KSAA.Master.Application.Features.Master.Queries.GLIncome_MappingQueries
{
    public class GetGLIncome_MappingByIdQuery : IRequest<Response<GLIncome_MappingViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetGLIncome_MappingByHandler : IRequestHandler<GetGLIncome_MappingByIdQuery, Response<GLIncome_MappingViewModel>>
    {
        private readonly IGLIncome_MappingService _GLIncome_MappingService;
        private readonly IMapper _mapper;

        public GetGLIncome_MappingByHandler(IGLIncome_MappingService GLIncome_MappingService, IMapper mapper)
        {
            _GLIncome_MappingService = GLIncome_MappingService;
            _mapper = mapper;
        }
        public async Task<Response<GLIncome_MappingViewModel>> Handle(GetGLIncome_MappingByIdQuery request, CancellationToken cancellationToken)
        {
            var geGLIncome_MappingById = await _GLIncome_MappingService.GetGLIncome_MappingById(request.Id);
            return new Response<GLIncome_MappingViewModel>(geGLIncome_MappingById);
        }
    }
}
