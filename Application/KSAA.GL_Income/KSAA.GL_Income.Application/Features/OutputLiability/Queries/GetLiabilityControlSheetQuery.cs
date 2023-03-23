using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.OutputLiability.Queries
{
    public class GetLiabilityControlSheetQuery : IRequest<Response<OutputLiabilityListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetLiabilityControlSheetQueryHandler : IRequestHandler<GetLiabilityControlSheetQuery, Response<OutputLiabilityListModel>>
    {
        private readonly IOutputLiabilityService _outputLiabilityService;

        public GetLiabilityControlSheetQueryHandler(IOutputLiabilityService outputLiabilityService)
        {
            _outputLiabilityService = outputLiabilityService;
        }
        public async Task<Response<OutputLiabilityListModel>> Handle(GetLiabilityControlSheetQuery request, CancellationToken cancellationToken)
        {
            var outputLiabilityList = await _outputLiabilityService.GetOutputLiabilityControlSheet(request.Month, request.Year);
            return new Response<OutputLiabilityListModel>(outputLiabilityList);
        }
    }
}