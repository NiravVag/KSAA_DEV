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
    public class GenComparisonSheetCommand : IRequest<Response<ComparisonReportSLEInvoiceListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GenComparisonSheetCommandHandler : IRequestHandler<GenComparisonSheetCommand, Response<ComparisonReportSLEInvoiceListModel>>
    {
        private readonly IComparisonReportService _comparisonReport;

        public GenComparisonSheetCommandHandler(IComparisonReportService comparisonReport)
        {
            _comparisonReport = comparisonReport;
        }
        public async Task<Response<ComparisonReportSLEInvoiceListModel>> Handle(GenComparisonSheetCommand request, CancellationToken cancellationToken)
        {
            var comparisonGen = await _comparisonReport.GenComparisonSheetSLEInvoice(request);
            return new Response<ComparisonReportSLEInvoiceListModel>(comparisonGen);
        }
    }
}
