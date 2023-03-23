using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Queries;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AdvRecAmendmentController : BaseApiController
    {
        private readonly IAdvaceReceivedService advaceReceivedService;
        private readonly IAdvanceAdjustmentService advanceAdjustmentModuleService;

        public AdvRecAmendmentController(IAdvaceReceivedService advaceReceivedService, IAdvanceAdjustmentService advanceAdjustmentModuleService)
        {
            this.advaceReceivedService = advaceReceivedService;
            this.advanceAdjustmentModuleService = advanceAdjustmentModuleService;
        }

        [HttpPost]
        [Route("GetAdvanceReceivedList")]
        public async Task<IActionResult> GetAdvanceReceivedList(GetAllAdvanceReceivedModuleQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GetAdvReceivedMonthYear")]
        public async Task<IActionResult> GetAdvReceivedMonthYear(GetAdvReceivedMonthYearQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetReceivedAmendmentById")]
        public async Task<IActionResult> GetReceivedAmendmentById(GetReceivedAmendmentByIdCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("AddReceivedAmendmentById")]
        public async Task<IActionResult> AddReceivedAmendmentById(AddReceivedAmendmentByIdCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetPreviewAddAmendmentById")]
        public async Task<IActionResult> GetPreviewAddAmendmentById(GetPreviewAddAmendmentByIdQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAdvanceAdjustmentList")]
        public async Task<IActionResult> GetAdvanceAdjustmentList(GetAdvanceAdjustmentQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAdvanceRegisterDetailById")]
        public async Task<IActionResult> GetAdvanceRegisterDetailById(GetAdvanceAdjustmentByIdQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetSLInvoiceNoList")]
        public async Task<IActionResult> GetSLInvoiceNoList(GetGetSLInvoiceNoQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("AddTagInvoiceById")]
        public async Task<IActionResult> AddTagInvoiceById(AddTagInvoiceByIdCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetSLInvoiceDetailById")]
        public async Task<IActionResult> GetSLInvoiceDetailById(GetSLInvoiceDetailByIdQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
