namespace KSAA.Master.ApiServices.Controllers.V1
{
    using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
    using KSAA.Master.Application.Features.Master.Commands.UpdateInvoiceAmendmentDataCommand;
    using KSAA.Master.Application.Features.Master.Queries.DocumetTypeQueries;
    using KSAA.Master.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class DocumentTypeController : BaseApiController
    {
        private readonly IDocumentTypeService documentTypeService;
        private ILogger<DocumentTypeController> _logger;

        public DocumentTypeController(IDocumentTypeService documentTypeService, ILogger<DocumentTypeController> logger)
        {
            this.documentTypeService = documentTypeService;
            _logger = logger;
        }


        [HttpPost]
        [Route("CreateDocumentType")]
        public async Task<IActionResult> Post(CreateDocumentTypeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllDocumentType")]
        public async Task<IActionResult> GetAllDocumentType(GetAllDocumentTypeQuery command)
        {

            return this.Ok(await this.Mediator.Send(command));

        }

        [HttpGet]
        [Route("GetDocumentTypeById/{id}")]
        public async Task<IActionResult> GetDocumentTypeById(int id)
        {
            var getDocumentTypeByIdQuery = new GetDocumentTypeByIdQuery()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(getDocumentTypeByIdQuery));
        }

        [HttpPut]
        [Route("UpdateDocumentTypeById")]
        public async Task<IActionResult> UpdateDocumentTypeById(UpdateDocumentTypeCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpDelete("DeleteDocumentTypeById/{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            var deleteUserByIdQuery = new DeleteDocumentTypeCommand()
            {
                Id = id,
            };
            return this.Ok(await this.Mediator.Send(deleteUserByIdQuery));
        }

        [HttpPost]
        [Route("GetPreViewDocument")]
        public async Task<IActionResult> GetPreViewDocument(GetPreviewDocumentUploadQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetData")]
        public async Task<IActionResult> GetData(GetDocumentDataQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("DeleteData")]
        public async Task<IActionResult> DeleteData(DeleteDataCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("UpdateInvoiceAmendment")]
        public async Task<IActionResult> UpdateInvoiceAmendment(UpdateInvoiceAmendmentCommand command)
        {
            _logger.LogInformation("step-1 in controller - UpdateInvoiceAmendment");
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}