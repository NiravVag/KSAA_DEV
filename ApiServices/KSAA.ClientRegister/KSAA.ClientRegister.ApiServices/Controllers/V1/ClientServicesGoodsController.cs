using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientServicesGoodsQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSAA.ClientRegister.ApiServices.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientServicesGoodsController : BaseApiController
    {
        public IClientServicesGoodsService ClientServicesGoodsService { get; }

        public ClientServicesGoodsController(IClientServicesGoodsService ClientServicesGoodsService)
        {
            this.ClientServicesGoodsService = ClientServicesGoodsService;
        }
        [HttpPost]
        [Route("CreateClientServicesGoods")]
        public async Task<IActionResult> Post(CreateClientServicesGoodsCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllClientServicesGoods")]
        public async Task<IActionResult> GetAllClientServicesGoods(GetAllClientServicesGoodsQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetClientServicesGoodsById/{id}")]
        public async Task<IActionResult> GetClientServicesGoodsById(long id)
        {
            var getClientServicesGoodsByIdQuery = new GetClientServicesGoodsByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getClientServicesGoodsByIdQuery));
        }

        [HttpPut("UpdateClientServicesGoodsById")]
        public async Task<IActionResult> UpdateClientServicesGoodsById(UpdateClientServicesGoodsCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteClientServicesGoodsById/{id}")]
        public async Task<IActionResult> DeleteClientServicesGoodsById(long id)
        {
            var deleteUserByIdQuery = new DeleteClientServicesGoodsCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}