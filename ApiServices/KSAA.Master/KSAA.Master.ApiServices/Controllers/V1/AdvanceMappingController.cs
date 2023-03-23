using KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand;
using KSAA.Master.Application.Features.Master.Queries.AdvanceMappingQueries;
using KSAA.Master.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.Master.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AdvanceMappingController : BaseApiController
    {
        private readonly IAdvanceMappingService AdvanceMappingService;

        public AdvanceMappingController(IAdvanceMappingService AdvanceMappingService)
        {
            this.AdvanceMappingService = AdvanceMappingService;
        }


        [HttpPost]
        [Route("CreateAdvanceMapping")]
        public async Task<IActionResult> Post(CreateAdvanceMappingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllAdvanceMapping")]
        public async Task<IActionResult> GetAllAdvanceMapping(GetAllAdvanceMappingQuery command)
        {

            return this.Ok(await this.Mediator.Send(command));

        }

        [HttpGet]
        [Route("GetAdvanceMappingById/{id}")]
        public async Task<IActionResult> GetAdvanceMappingById(int id)
        {
            var getAdvanceMappingByIdQuery = new GetAdvanceMappingByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getAdvanceMappingByIdQuery));
        }

        [HttpPut]
        [Route("UpdateAdvanceMappingById")]
        public async Task<IActionResult> UpdateAdvanceMappingById(UpdateAdvanceMappingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteAdvanceMappingById/{id}")]
        public async Task<IActionResult> DeleteAdvanceMapping(int id)
        {
            var deleteUserByIdQuery = new DeleteAdvanceMappingCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}