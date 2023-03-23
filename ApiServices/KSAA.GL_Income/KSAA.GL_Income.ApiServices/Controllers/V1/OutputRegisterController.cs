using KSAA.GL_Income.Application.Features.OutputRegister.Queries;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class OutputRegisterController : BaseApiController
    {
        private readonly IOutputRegisterService outputRegisterService;
        public OutputRegisterController(IOutputRegisterService outputRegisterService)
        {
            this.outputRegisterService = outputRegisterService;
        }

        [HttpPost]
        [Route("GetOutputRegisterList")]
        public async Task<IActionResult> GetOutputRegisterList(GetOutputRegisterQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
