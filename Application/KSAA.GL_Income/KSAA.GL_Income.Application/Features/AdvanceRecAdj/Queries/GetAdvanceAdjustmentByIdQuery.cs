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
    public class GetAdvanceAdjustmentByIdQuery : IRequest<Response<AdvanceAdjustmentViewModel>>
    {
        public long Id { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetAdvanceAdjustmentByIdQueryHandler : IRequestHandler<GetAdvanceAdjustmentByIdQuery, Response<AdvanceAdjustmentViewModel>>
    {
        private readonly IAdvanceAdjustmentService _advaceAdjustmentService;

        public GetAdvanceAdjustmentByIdQueryHandler(IAdvanceAdjustmentService advaceAdjustmentService)
        {
            _advaceAdjustmentService = advaceAdjustmentService;
        }

        public async Task<Response<AdvanceAdjustmentViewModel>> Handle(GetAdvanceAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            var advanceAmendment = await _advaceAdjustmentService.GetAdvanceAdjustmentById(request.Id, request.Month, request.Year);
            return new Response<AdvanceAdjustmentViewModel>(advanceAmendment);
        }
    }
}
