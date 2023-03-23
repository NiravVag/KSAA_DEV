using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientAuthorizedSignatoryQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.ClientRegister.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientAuthorizedSignatoryController : BaseApiController
    {
        private readonly IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService;

        public ClientAuthorizedSignatoryController(IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService)
        {
            this.ClientAuthorizedSignatoryService = ClientAuthorizedSignatoryService;
        }


        [HttpPost]
        [Route("CreateClientAuthorizedSignatory")]
        public async Task<IActionResult> Post(CreateClientAuthorizedSignatoryCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllClientAuthorizedSignatory")]
        public async Task<IActionResult> GetAllClientAuthorizedSignatory(GetAllClientAuthorizedSignatoryQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetClientAuthorizedSignatoryById/{id}")]
        public async Task<IActionResult> GetClientAuthorizedSignatoryById(long id)
        {
            var getClientAuthorizedSignatoryByIdQuery = new GetClientAuthorizedSignatoryByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getClientAuthorizedSignatoryByIdQuery));
        }

        [HttpPut("UpdateClientAuthorizedSignatoryById")]
        public async Task<IActionResult> UpdateClientAuthorizedSignatoryById(UpdateClientAuthorizedSignatoryCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteClientAuthorizedSignatoryById/{id}")]
        public async Task<IActionResult> DeleteClientAuthorizedSignatoryById(long id)
        {
            var deleteUserByIdQuery = new DeleteClientAuthorizedSignatoryCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}