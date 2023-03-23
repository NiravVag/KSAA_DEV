using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.Features.GLIncome.Queries;
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
    public class GetSLEInvoiceQuery : IRequest<Response<ComparisonReportSLEInvoiceListModel>>
    {
        public string? Action { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetSLEInvoiceQueryHandler : IRequestHandler<GetSLEInvoiceQuery, Response<ComparisonReportSLEInvoiceListModel>>
    {
        private readonly IComparisonReportService _comparisonReportService;

        public GetSLEInvoiceQueryHandler(IComparisonReportService comparisonReportService)
        {
            _comparisonReportService = comparisonReportService;
        }
        public async Task<Response<ComparisonReportSLEInvoiceListModel>> Handle(GetSLEInvoiceQuery request, CancellationToken cancellationToken)
        {
            var glIncomeList = await _comparisonReportService.GetComparisonReportSheetSLEInvoice(request.Month, request.Year, request.Action);
            return new Response<ComparisonReportSLEInvoiceListModel>(glIncomeList);
        }
    }
}
