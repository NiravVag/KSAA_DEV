namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand;
    using KSAA.Master.Application.Features.Master.Queries.VendorCodeQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class VendorCodeController : BaseApiController
    {
        private readonly IVendorCodeService VendorCodeService;

        public VendorCodeController(IVendorCodeService VendorCodeService)
        {
            this.VendorCodeService = VendorCodeService;
        }


        [HttpPost]
        [Route("CreateVendorCode")]
        public async Task<IActionResult> Post(CreateVendorCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllVendorCode")]
        public async Task<IActionResult> GetAllVendorCode(GetAllVendorCodeQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetVendorCodeById/{id}")]
        public async Task<IActionResult> GetVendorCodeById(long id)
        {
            var getVendorCodeByIdQuery = new GetVendorCodeByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getVendorCodeByIdQuery));
        }

        [HttpPut("UpdateVendorCodeById")]
        public async Task<IActionResult> UpdateVendorCodeById(UpdateVendorCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteVendorCodeById/{id}")]
        public async Task<IActionResult> DeleteVendorCodeById(long id)
        {
            var deleteUserByIdQuery = new DeleteVendorCodeCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}