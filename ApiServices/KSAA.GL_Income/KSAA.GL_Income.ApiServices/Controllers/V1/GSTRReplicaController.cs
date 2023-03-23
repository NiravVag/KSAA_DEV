using KSAA.GL_Income.Application.Features.GSTR.Queries.GSTRReplica;
using KSAA.GL_Income.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.GL_Income.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class GSTRReplicaController : BaseApiController
    {
        private readonly IGLIncomeService GLIncomeService;

        public GSTRReplicaController(IGLIncomeService GLIncomeService)
        {
            this.GLIncomeService = GLIncomeService;
        }

        [HttpPost]
        [Route("GetGSTRReplicaView")]
        public async Task<IActionResult> GetGSTRReplicaView(GSTRReplicaQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
