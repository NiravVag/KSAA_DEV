namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.CompanyCommand;
    using KSAA.Master.Application.Features.Master.Queries.CompanyQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService CompanyService;

        public CompanyController(ICompanyService CompanyService)
        {
            this.CompanyService = CompanyService;
        }


        [HttpPost]
        [Route("CreateCompany")]
        public async Task<IActionResult> Post(CreateCompanyCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany(GetAllCompanyQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpGet("GetCompanyById/{id}")]
        public async Task<IActionResult> GetCompanyById(long id)
        {
            var getCompanyByIdQuery = new GetCompanyByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getCompanyByIdQuery));
        }

        [HttpPut("UpdateCompanyById")]
        public async Task<IActionResult> UpdateCompanyById(UpdateCompanyCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteCompanyById/{id}")]
        public async Task<IActionResult> DeleteCompanyById(long id)
        {
            var deleteUserByIdQuery = new DeleteCompanyCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }
    }
}