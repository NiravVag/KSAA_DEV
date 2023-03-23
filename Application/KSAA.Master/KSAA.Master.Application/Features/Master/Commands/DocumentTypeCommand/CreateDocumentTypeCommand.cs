using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand
{
    public partial class CreateDocumentTypeCommand : IRequest<Response>
    {
        [Required]
        public virtual string? BillType { get; set; }
        [Required]
        public virtual string? Document_Code { get; set; }
        [Required]
        public virtual string? Document_Type { get; set; }
        [Required]
        public virtual string? OurSoftwareProcessing { get; set; }
        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/
    }

    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, Response>
    {
        private readonly IDocumentTypeService _documentTypeService;
        public CreateDocumentTypeCommandHandler(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }
        public async Task<Response> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {

            var documentObject = await _documentTypeService.AddDocumentType(request);
            return new Response("Document Type Add Successfully");
        }
    }
}