using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GLIncome.Commands.ComparisonReport
{
    public class UpdateComparisonSheetCommand : IRequest<Response<ComparisonReportSLEWayListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class UpdateComparisonSheetCommandHandler : IRequestHandler<UpdateComparisonSheetCommand, Response<ComparisonReportSLEWayListModel>>
    {
        private readonly IComparisonReportService _comparisonReport;

        public UpdateComparisonSheetCommandHandler(IComparisonReportService comparisonReport)
        {
            _comparisonReport = comparisonReport;
        }
        public async Task<Response<ComparisonReportSLEWayListModel>> Handle(UpdateComparisonSheetCommand request, CancellationToken cancellationToken)
        {
            var comparisonGen = await _comparisonReport.UpdateComparisonSheetSLEWay(request);
            return new Response<ComparisonReportSLEWayListModel>(comparisonGen);
        }
    }
}
