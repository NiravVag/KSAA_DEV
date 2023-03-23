using KSAA.GL_Income.Application.Features.GLIncome.Commands.ComparisonReport;
using KSAA.GL_Income.Application.Features.GLIncome.Queries;
using KSAA.GL_Income.Application.Features.GLIncome.Queries.ComparisonReport;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ComparisonReportController : BaseApiController
    {
        private readonly IComparisonReportService comparisonReportService;

        public ComparisonReportController(IComparisonReportService comparisonReportService)
        {
            this.comparisonReportService = comparisonReportService;
        }

        [HttpPost]
        [Route("GetComparisonReportSLEInvoiceSheet")]
        public async Task<IActionResult> GetComparisonReportSLEInvoiceSheet(GetSLEInvoiceQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetComparisonReportSLEWaySheet")]
        public async Task<IActionResult> GetComparisonReportSLEWaySheet(GetSLEWayQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GenComparisonSheetSLEInvoice")]
        public async Task<IActionResult> GenComparisonSheetSLEInvoice(GenComparisonSheetCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("UpdateComparisonSheetSLEWay")]
        public async Task<IActionResult> UpdateComparisonSheetSLEWay(UpdateComparisonSheetCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("SLEInvoiceUpdateAction")]
        public async Task<IActionResult> SLEInvoiceUpdateAction(UpdateSLEInvoiceActionCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("SLEWayUpdateAction")]
        public async Task<IActionResult> SLEWayUpdateAction(UpdateSLEWayActionCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetPreviewSLDocument")]
        public async Task<IActionResult> GetPreviewSLDocument(GetPreviewSLDocumentQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
