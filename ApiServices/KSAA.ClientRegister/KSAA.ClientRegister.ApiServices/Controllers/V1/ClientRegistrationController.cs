using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientRegistrationQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.ClientRegister.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientRegistrationController : BaseApiController
    {
        public IClientRegistrationService ClientRegistrationService { get; }

        public ClientRegistrationController(IClientRegistrationService ClientRegistrationService)
        {
            this.ClientRegistrationService = ClientRegistrationService;
        }
        [HttpPost]
        [Route("CreateClientRegistration")]
        public async Task<IActionResult> Post(CreateClientRegistrationCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllClientRegistration")]
        public async Task<IActionResult> GetAllClientRegistration(GetAllClientRegistrationQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetClientRegistrationById/{id}")]
        public async Task<IActionResult> GetClientRegistrationById(long id)
        {
            var getClientRegistrationByIdQuery = new GetClientRegistrationByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getClientRegistrationByIdQuery));
        }

        [HttpPut("UpdateClientRegistrationById")]
        public async Task<IActionResult> UpdateClientRegistrationById(UpdateClientRegistrationCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteClientRegistrationById/{id}")]
        public async Task<IActionResult> DeleteClientRegistrationById(long id)
        {
            var deleteUserByIdQuery = new DeleteClientRegistrationCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}