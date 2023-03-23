using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
using KSAA.GL_Income.Application.Features.GLIncome.Queries.ControlSheetGLSL;
using KSAA.GL_Income.Application.Features.OutputLiability.Commands;
using KSAA.GL_Income.Application.Features.OutputLiability.Queries;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class OutputLiabilityController : BaseApiController
    {
        private readonly IOutputLiabilityService outputLiabilityService;

        public OutputLiabilityController(IOutputLiabilityService outputLiabilityService)
        {
            this.outputLiabilityService = outputLiabilityService;
        }

        [HttpPost("LiabilityControlSheetGen")]
        public async Task<IActionResult> LiabilityControlSheetGen(GenLiabilityControlSheetCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetLiabilityControlSheet")]
        public async Task<IActionResult> GetLiabilityControlSheet(GetLiabilityControlSheetQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("AddToSupply")]
        public async Task<IActionResult> AddToSupply(AddToSupplyOutputLiabliyCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetPreViewDocument")]
        public async Task<IActionResult> GetPreViewDocument(GetPreviewLiablityControlQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("UpdateLiabilityControlDataById")]
        public async Task<IActionResult> UpdateLiabilityControlDataById(UpdateLiabilityControlDataByIdCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
