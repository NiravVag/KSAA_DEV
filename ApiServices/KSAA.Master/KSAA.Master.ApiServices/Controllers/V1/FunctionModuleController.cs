namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand;
    using KSAA.Master.Application.Features.Master.Queries.FunctionModuleQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class FunctionModuleController : BaseApiController
    {
        private readonly IFunctionModuleService functionModuleService;

        public FunctionModuleController(IFunctionModuleService functionModuleService)
        {
            this.functionModuleService = functionModuleService;
        }

        [HttpPost]
        [Route("CreateFunctionModule")]
        public async Task<IActionResult> Post(CreateFunctionModuleCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllFunctionModule")]
        public async Task<IActionResult> GetAllFunctionModule(GetAllFunctionModuleQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFunctionModuleById/{id}")]
        public async Task<IActionResult> GetFunctionModuleById(int id)
        {
            var getFunctionByIdQuery = new GetFunctionModuleByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getFunctionByIdQuery));
        }

        [HttpPut]
        [Route("UpdateFunctionModuleById")]
        public async Task<IActionResult> UpdateFunctionModuleById(UpdateFunctionModuleCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteFunctionModuleById/{id}")]
        public async Task<IActionResult> DeleteFunctionModuleById(int id)
        {
            var deleteUserByIdQuery = new DeleteFunctionModuleCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}
