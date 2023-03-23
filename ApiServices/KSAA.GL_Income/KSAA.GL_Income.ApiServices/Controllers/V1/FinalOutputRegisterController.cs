using KSAA.GL_Income.Application.Features.FinalOutputRegister.Commands;
using KSAA.GL_Income.Application.Features.FinalOutputRegister.Queries;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class FinalOutputRegisterController : BaseApiController
    {
        private readonly IFinalOutputRegisterService finalOutputRegisterService;

        public FinalOutputRegisterController(IFinalOutputRegisterService finalOutputRegisterService)
        {
            this.finalOutputRegisterService = finalOutputRegisterService;
        }

        [HttpPost]
        [Route("FinalOutputRegisterList")]
        public async Task<IActionResult> GetFinalOutputRegisterList(GetFinalOutputRegisterQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("FinalOutputRegisterExport")]
        public async Task<IActionResult> FinalOutputRegisterExport(ExportFinalOutputQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GenFinalOutputRegister")]
        public async Task<IActionResult> GenFinalOutputRegister(GenFinalOutputRegisterCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
