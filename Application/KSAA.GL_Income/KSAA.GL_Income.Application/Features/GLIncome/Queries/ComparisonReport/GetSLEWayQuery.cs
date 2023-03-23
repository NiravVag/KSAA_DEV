using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GLIncome.Queries.ComparisonReport
{
    public class GetSLEWayQuery : IRequest<Response<ComparisonReportSLEWayListModel>>
    {
        public string? Action { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetSLEWayQueryHandler : IRequestHandler<GetSLEWayQuery, Response<ComparisonReportSLEWayListModel>>
    {
        private readonly IComparisonReportService _comparisonReportService;

        public GetSLEWayQueryHandler(IComparisonReportService comparisonReportService)
        {
            _comparisonReportService = comparisonReportService;
        }

        public async Task<Response<ComparisonReportSLEWayListModel>> Handle(GetSLEWayQuery request, CancellationToken cancellationToken)
        {
            var glIncomeList = await _comparisonReportService.GetComparisonReportSheetSLEWay(request.Month, request.Year, request.Action);
            return new Response<ComparisonReportSLEWayListModel>(glIncomeList);
        }
    }
}
