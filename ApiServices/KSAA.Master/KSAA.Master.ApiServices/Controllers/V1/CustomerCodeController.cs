namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
    using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
    using KSAA.Master.Application.Features.Master.Queries.CustomerCodeQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class CustomerCodeController : BaseApiController
    {
        private readonly ICustomerCodeService CustomerCodeService;

        public CustomerCodeController(ICustomerCodeService CustomerCodeService)
        {
            this.CustomerCodeService = CustomerCodeService;
        }


        [HttpPost]
        [Route("CreateCustomerCode")]
        public async Task<IActionResult> Post(CreateCustomerCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllCustomerCode")]
        public async Task<IActionResult> GetAllCustomerCode(GetAllCustomerCodeQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetCustomerCodeById/{id}")]
        public async Task<IActionResult> GetCustomerCodeById(long id)
        {
            var getCustomerCodeByIdQuery = new GetCustomerCodeByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getCustomerCodeByIdQuery));
        }

        [HttpPut("UpdateCustomerCodeById")]
        public async Task<IActionResult> UpdateCustomerCodeById(UpdateCustomerCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteCustomerCodeById/{id}")]
        public async Task<IActionResult> DeleteCustomerCodeById(long id)
        {
            var deleteUserByIdQuery = new DeleteCustomerCodeCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}