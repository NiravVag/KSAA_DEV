using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
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
    public class GetAllGLIncome_MappingQuery : IRequest<Response<IEnumerable<GLIncome_MappingListModel>>>
    {
    }

    public class GetAllGLIncome_MappingQueryHandler : IRequestHandler<GetAllGLIncome_MappingQuery, Response<IEnumerable<GLIncome_MappingListModel>>>
    {
        private readonly IGLIncome_MappingService _GLIncome_MappingService;
        private readonly IMapper _mapper;

        public GetAllGLIncome_MappingQueryHandler(IGLIncome_MappingService GLIncome_MappingService, IMapper mapper)
        {
            _GLIncome_MappingService = GLIncome_MappingService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GLIncome_MappingListModel>>> Handle(GetAllGLIncome_MappingQuery request, CancellationToken cancellationToken)
        {
            var GLIncome_MappingList = await _GLIncome_MappingService.GetGLIncome_MappingList();

            return new Response<IEnumerable<GLIncome_MappingListModel>>(GLIncome_MappingList);
        }
    }
}