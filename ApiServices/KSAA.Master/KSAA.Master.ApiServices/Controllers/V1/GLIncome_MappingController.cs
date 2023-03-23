namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
    using KSAA.Master.Application.Features.Master.Queries.DocumetTypeQueries;
    using KSAA.Master.Application.Features.Master.Queries.GLIncome_MappingQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class GLIncome_MappingController : BaseApiController
    {
        private readonly IGLIncome_MappingService GLIncome_MappingService;

        public GLIncome_MappingController(IGLIncome_MappingService GLIncome_MappingService)
        {
            this.GLIncome_MappingService = GLIncome_MappingService;
        }


        [HttpPost]
        [Route("CreateGLIncome_Mapping")]
        public async Task<IActionResult> Post(CreateGLIncome_MappingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllGLIncome_Mapping")]
        public async Task<IActionResult> GetAllGLIncome_Mapping(GetAllGLIncome_MappingQuery command)
        {

            return this.Ok(await this.Mediator.Send(command));

        }

        [HttpGet]
        [Route("GetGLIncome_MappingById/{id}")]
        public async Task<IActionResult> GetGLIncome_MappingById(int id)
        {
            var getGLIncome_MappingByIdQuery = new GetGLIncome_MappingByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getGLIncome_MappingByIdQuery));
        }

        [HttpPut]
        [Route("UpdateGLIncome_MappingById")]
        public async Task<IActionResult> UpdateGLIncome_MappingById(UpdateGLIncome_MappingCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteGLIncome_MappingById/{id}")]
        public async Task<IActionResult> DeleteGLIncome_Mapping(int id)
        {
            var deleteUserByIdQuery = new DeleteGLIncome_MappingCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}