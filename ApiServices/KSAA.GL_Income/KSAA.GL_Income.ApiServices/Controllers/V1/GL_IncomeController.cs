namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
    using KSAA.GL_Income.Application.Features.GLIncome.Queries.ControlSheetGLSL;
    using KSAA.GL_Income.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class GL_IncomeController : BaseApiController
    {
        private readonly IGLIncomeService GLIncomeService;

        public GL_IncomeController(IGLIncomeService GLIncomeService)
        {
            this.GLIncomeService = GLIncomeService;
        }

        [HttpPost]
        [Route("GetGLIncomeControlSheet")]
        public async Task<IActionResult> GetGLIncomeControlSheet(GetGLIncomeControlSheetQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GenControlSheet")]
        public async Task<IActionResult> GenControlSheet(GenControlSheetCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("AddToSupply")]
        public async Task<IActionResult> AddToSupply(AddToSupplyCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GetSLMonthYear")]
        public async Task<IActionResult> GetSLMonthYear(GetSLMonthYearQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetPreViewDocument")]
        public async Task<IActionResult> GetPreViewDocument(GetPreviewControlDocumentQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
