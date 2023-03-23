using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand
{
    public class UpdateDocumentTypeCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? BillType { get; set; }
        public string? Document_Code { get; set; }
        public string? Document_Type { get; set; }
        public string? OurSoftwareProcessing { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public IsActive IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, Response>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public UpdateDocumentTypeCommandHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            await _documentTypeService.EditDocumentType(request);

            return new Response("Document Updated Successfully");
        }
    }
}
