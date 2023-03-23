namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand;
    using KSAA.Master.Application.Features.Master.Queries.PlantCodeQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class PlantCodeController : BaseApiController
    {
        private readonly IPlantCodeService PlantCodeService;

        public PlantCodeController(IPlantCodeService PlantCodeService)
        {
            this.PlantCodeService = PlantCodeService;
        }


        [HttpPost]
        [Route("CreatePlantCode")]
        public async Task<IActionResult> Post(CreatePlantCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllPlantCode")]
        public async Task<IActionResult> GetAllPlantCode(GetAllPlantCodeQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetPlantCodeById/{id}")]
        public async Task<IActionResult> GetPlantCodeById(int id)
        {
            var getPlantCodeByIdQuery = new GetPlantCodeByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getPlantCodeByIdQuery));
        }

        [HttpPut]
        [Route("UpdatePlantCodeById")]
        public async Task<IActionResult> UpdatePlantCodeById(UpdatePlantCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeletePlantCodeById/{id}")]
        public async Task<IActionResult> DeletePlantCodeById(long id)
        {
            var deleteUserByIdQuery = new DeletePlantCodeCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}