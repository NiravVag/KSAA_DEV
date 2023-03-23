namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
    using KSAA.Master.Application.Features.Master.Queries.DocumetTypeQueries;
    using KSAA.Master.Application.Features.Master.Queries.TBTaggingQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class TBTaggingController : BaseApiController
    {
        private readonly ITBTaggingService TBTaggingService;

        public TBTaggingController(ITBTaggingService TBTaggingService)
        {
            this.TBTaggingService = TBTaggingService;
        }


        [HttpPost]
        [Route("CreateTBTagging")]
        public async Task<IActionResult> Post(CreateTBTaggingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllTBTagging")]
        public async Task<IActionResult> GetAllTBTagging(GetAllTBTaggingQuery command)
        {

            return this.Ok(await this.Mediator.Send(command));

        }

        [HttpGet]
        [Route("GetTBTaggingById/{id}")]
        public async Task<IActionResult> GetTBTaggingById(int id)
        {
            var getTBTaggingByIdQuery = new GetTBTaggingByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getTBTaggingByIdQuery));
        }

        [HttpPut]
        [Route("UpdateTBTaggingById")]
        public async Task<IActionResult> UpdateTBTaggingById(UpdateTBTaggingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteTBTaggingById/{id}")]
        public async Task<IActionResult> DeleteTBTagging(int id)
        {
            var deleteUserByIdQuery = new DeleteTBTaggingCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}