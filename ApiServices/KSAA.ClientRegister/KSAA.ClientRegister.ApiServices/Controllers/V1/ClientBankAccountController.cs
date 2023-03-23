using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientBankAccountQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.ClientRegister.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientBankAccountController : BaseApiController
    {
        public IClientBankAccountService ClientBankAccountService { get; }

        public ClientBankAccountController(IClientBankAccountService ClientBankAccountService)
        {
            this.ClientBankAccountService = ClientBankAccountService;
        }
        [HttpPost]
        [Route("CreateClientBankAccount")]
        public async Task<IActionResult> Post(CreateClientBankAccountCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllClientBankAccount")]
        public async Task<IActionResult> GetAllClientBankAccount(GetAllClientBankAccountQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetClientBankAccountById/{id}")]
        public async Task<IActionResult> GetClientBankAccountById(long id)
        {
            var getClientBankAccountByIdQuery = new GetClientBankAccountByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getClientBankAccountByIdQuery));
        }

        [HttpPut("UpdateClientBankAccountById")]
        public async Task<IActionResult> UpdateClientBankAccountById(UpdateClientBankAccountCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteClientBankAccountById/{id}")]
        public async Task<IActionResult> DeleteClientBankAccountById(long id)
        {
            var deleteUserByIdQuery = new DeleteClientBankAccountCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}