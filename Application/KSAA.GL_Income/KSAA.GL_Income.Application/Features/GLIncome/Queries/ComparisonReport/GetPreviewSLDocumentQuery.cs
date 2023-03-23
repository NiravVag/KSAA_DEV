using AutoMapper;
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
    public class GetPreviewSLDocumentQuery : IRequest<Response<List<CompairsonReportsSLEInvoiceEWay>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? Action { get; set; }
    }

    public class GetPreviewSLDocumentQueryHandler : IRequestHandler<GetPreviewSLDocumentQuery, Response<List<CompairsonReportsSLEInvoiceEWay>>>
    {
        private readonly IComparisonReportService _comparisonReportService;
        private readonly IMapper _mapper;

        public GetPreviewSLDocumentQueryHandler(IComparisonReportService comparisonReportService, IMapper mapper)
        {
            _comparisonReportService = comparisonReportService;
            _mapper = mapper;
        }
        public async Task<Response<List<CompairsonReportsSLEInvoiceEWay>>> Handle(GetPreviewSLDocumentQuery request, CancellationToken cancellationToken)
        {
            var comparisonReportList = await _comparisonReportService.GetPreviewSLDocumentList(request.Month, request.Year, request.Action);
            return new Response<List<CompairsonReportsSLEInvoiceEWay>>(comparisonReportList);
        }
    }
}
