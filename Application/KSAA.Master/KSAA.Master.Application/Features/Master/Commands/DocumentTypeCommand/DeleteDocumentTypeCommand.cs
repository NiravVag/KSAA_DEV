using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand
{
    public class DeleteDocumentTypeCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand>
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DeleteDocumentTypeCommandHandler(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        public async Task<Unit> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            await _documentTypeService.DeleteDocumentType(request);
            return Unit.Value;

        }
    }
}