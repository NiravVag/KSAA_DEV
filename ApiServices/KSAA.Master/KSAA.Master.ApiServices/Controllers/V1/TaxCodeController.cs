namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Commands.TaxCodeCommand;
    using KSAA.Master.Application.Features.Master.Queries.TaxCodeQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class TaxCodeController : BaseApiController
    {
        private readonly ITaxCodeService taxCodeService;

        public TaxCodeController(ITaxCodeService taxCodeService)
        {
            this.taxCodeService = taxCodeService;
        }


        [HttpPost]
        [Route("CreateTaxCode")]
        public async Task<IActionResult> Post(CreateTaxCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllTaxCode")]
        public async Task<IActionResult> GetAllTaxCode(GetAllTaxCodeQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetTaxCodeById/{id}")]
        public async Task<IActionResult> GetTaxCodeById(int id)
        {
            var getTaxCodeByIdQuery = new GetTaxCodeByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getTaxCodeByIdQuery));
        }

        [HttpPut("UpdateTaxCodeById")]
        public async Task<IActionResult> UpdateTaxCodeById(UpdateTaxCodeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteTaxCodeById/{id}")]
        public async Task<IActionResult> DeleteTaxCodeById(int id)
        {
            var deleteUserByIdQuery = new DeleteTaxCodeCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}