using KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand;
using KSAA.Master.Application.Features.Master.Queries.GSTOutputLiabilityCodesQueries;
using KSAA.Master.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.Master.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class GSTOutputLiabilityCodesController : BaseApiController
    {
        private readonly IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService;

        public GSTOutputLiabilityCodesController(IGSTOutputLiabilityCodesService GSTOutputLiabilityCodesService)
        {
            this.GSTOutputLiabilityCodesService = GSTOutputLiabilityCodesService;
        }

        [HttpPost]
        [Route("CreateGSTOutputLiabilityCodes")]
        public async Task<IActionResult> Post(CreateGSTOutputLiabilityCodesCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllGSTOutputLiabilityCodes")]
        public async Task<IActionResult> GetAllGSTOutputLiabilityCodes(GetAllGSTOutputLiabilityCodesQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetGSTOutputLiabilityCodesById/{id}")]
        public async Task<IActionResult> GetGSTOutputLiabilityCodesById(int id)
        {
            var getGSTOutputLiabilityCodesByIdQuery = new GetGSTOutputLiabilityCodesByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getGSTOutputLiabilityCodesByIdQuery));
        }

        [HttpPut]
        [Route("UpdateGSTOutputLiabilityCodesById")]
        public async Task<IActionResult> UpdateGSTOutputLiabilityCodesById(UpdateGSTOutputLiabilityCodesCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteGSTOutputLiabilityCodesById/{id}")]
        public async Task<IActionResult> DeleteGSTOutputLiabilityCodes(int id)
        {
            var deleteUserByIdQuery = new DeleteGSTOutputLiabilityCodesCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}