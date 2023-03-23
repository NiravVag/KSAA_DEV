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
    public class UpdateSLEInvoiceActionCommand : IRequest<Response<HttpResponseMessage>>
    {
        public int Id { get; set; }
        public string? UpdateType { get; set; }
        public string? Action { get; set; }
        public int Year { get; set; }
    }

    public class UpdateSLEInvoiceActionCommandHandler : IRequestHandler<UpdateSLEInvoiceActionCommand, Response<HttpResponseMessage>>
    {
        private readonly IComparisonReportService _comparisonReport;

        public UpdateSLEInvoiceActionCommandHandler(IComparisonReportService comparisonReport)
        {
            _comparisonReport = comparisonReport;
        }
        public async Task<Response<HttpResponseMessage>> Handle(UpdateSLEInvoiceActionCommand request, CancellationToken cancellationToken)
        {
            var comparisonGen = await _comparisonReport.UpdateSLEInvoiceAction(request);
            return new Response<HttpResponseMessage>(comparisonGen);
        }
    }
}
