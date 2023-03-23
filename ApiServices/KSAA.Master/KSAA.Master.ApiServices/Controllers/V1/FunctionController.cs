namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.FunctionCommand;
    using KSAA.Master.Application.Features.Master.Queries.FunctionQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class FunctionController : BaseApiController
    {
        private readonly IFunctionService functionService;

        public FunctionController(IFunctionService functionService)
        {
            this.functionService = functionService;
        }

        [HttpPost]
        [Route("CreateFunction")]
        public async Task<IActionResult> Post(CreateFunctionCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllFunction")]
        public async Task<IActionResult> GetAllFunction(GetAllFunctionQuery command)
        {

            return this.Ok(await this.Mediator.Send(command));

        }

        [HttpGet]
        [Route("GetFunctionById/{id}")]
        public async Task<IActionResult> GetFunctionById(int id)
        {
            var getFunctionByIdQuery = new GetFunctionByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getFunctionByIdQuery));
        }

        [HttpPut]
        [Route("UpdateFunctionById")]
        public async Task<IActionResult> UpdateFunctionById(UpdateFunctionCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteFunctionById/{id}")]
        public async Task<IActionResult> DeleteFunction(int id)
        {
            var deleteUserByIdQuery = new DeleteFunctionCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}