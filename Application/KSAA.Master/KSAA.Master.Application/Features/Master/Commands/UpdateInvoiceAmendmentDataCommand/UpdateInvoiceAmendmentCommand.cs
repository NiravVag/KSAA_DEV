using AutoMapper;
using KSAA.Master.Application.DTOs.IAD;
using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.UpdateInvoiceAmendmentDataCommand
{
    public class UpdateInvoiceAmendmentCommand : IRequest<Response>
    {
        public List<InvoiceAmendmentUpdateViewModel> invoiceAmendmentUpdates { get; set; }
    }
    public class UpdateInvoiceAmendmentCommandHandler : IRequestHandler<UpdateInvoiceAmendmentCommand, Response>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public UpdateInvoiceAmendmentCommandHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateInvoiceAmendmentCommand request, CancellationToken cancellationToken)
        {
            await _documentTypeService.UpdateInvoiceAmendmentData(request.invoiceAmendmentUpdates);
            return new Response("Invoice Amendment Data Updated Successfully");
        }
    }
}