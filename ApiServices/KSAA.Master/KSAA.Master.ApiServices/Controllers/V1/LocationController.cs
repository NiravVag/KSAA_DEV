namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.LocationCommand;
    using KSAA.Master.Application.Features.Master.Queries.LocationQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class LocationController : BaseApiController
    {
        private readonly ILocationService LocationService;

        public LocationController(ILocationService LocationService)
        {
            this.LocationService = LocationService;
        }


        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> Post(CreateLocationCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllLocation")]
        public async Task<IActionResult> GetAllLocation(GetAllLocationQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetLocationById/{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var getLocationByIdQuery = new GetLocationByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getLocationByIdQuery));
        }

        [HttpPut]
        [Route("UpdateLocationById")]
        public async Task<IActionResult> UpdateLocationById(UpdateLocationCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteLocationById/{id}")]
        public async Task<IActionResult> DeleteLocationById(long id)
        {
            var deleteUserByIdQuery = new DeleteLocationCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}