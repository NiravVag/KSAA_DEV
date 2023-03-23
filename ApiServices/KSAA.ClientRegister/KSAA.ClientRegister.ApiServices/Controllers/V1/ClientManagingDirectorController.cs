using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientManagingDirectorQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.ClientRegister.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientManagingDirectorController : BaseApiController
    {
        public IClientManagingDirectorService ClientManagingDirectorService { get; }

        public ClientManagingDirectorController(IClientManagingDirectorService ClientManagingDirectorService)
        {
            this.ClientManagingDirectorService = ClientManagingDirectorService;
        }
        [HttpPost]
        [Route("CreateClientManagingDirector")]
        public async Task<IActionResult> Post(CreateClientManagingDirectorCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllClientManagingDirector")]
        public async Task<IActionResult> GetAllClientManagingDirector(GetAllClientManagingDirectorQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetClientManagingDirectorById/{id}")]
        public async Task<IActionResult> GetClientManagingDirectorById(long id)
        {
            var getManagingDirectorByIdQuery = new GetClientManagingDirectorByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getManagingDirectorByIdQuery));
        }

        [HttpPut("UpdateClientManagingDirectorById")]
        public async Task<IActionResult> UpdateClientManagingDirectorById(UpdateClientManagingDirectorCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteClientManagingDirectorById/{id}")]
        public async Task<IActionResult> DeleteClientManagingDirectorById(long id)
        {
            var deleteUserByIdQuery = new DeleteClientManagingDirectorCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}