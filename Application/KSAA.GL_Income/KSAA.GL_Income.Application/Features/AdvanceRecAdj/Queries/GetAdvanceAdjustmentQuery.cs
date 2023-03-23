using AutoMapper;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.AdvanceRecAdj.Queries
{
    public class GetAdvanceAdjustmentQuery : IRequest<Response<List<AdvanceAdjustmentViewModel>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetAdvanceAdjustmentModuleQueryHandler : IRequestHandler<GetAdvanceAdjustmentQuery, Response<List<AdvanceAdjustmentViewModel>>>
    {
        private readonly IAdvanceAdjustmentService _advanceAdjustmentService;
        private readonly IMapper _mapper;

        public GetAdvanceAdjustmentModuleQueryHandler(IAdvanceAdjustmentService advanceAdjustmentService, IMapper mapper)
        {
            _advanceAdjustmentService = advanceAdjustmentService;
            _mapper = mapper;
        }
        public async Task<Response<List<AdvanceAdjustmentViewModel>>> Handle(GetAdvanceAdjustmentQuery request, CancellationToken cancellationToken)
        {
            var advanceAdjustmentList = await _advanceAdjustmentService.GetAdvanceAdjustmentList(request.Month, request.Year);
            return new Response<List<AdvanceAdjustmentViewModel>>(advanceAdjustmentList);
        }
    }
}
