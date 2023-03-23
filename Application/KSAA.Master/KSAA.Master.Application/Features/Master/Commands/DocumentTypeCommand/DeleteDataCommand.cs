using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand
{
    public class DeleteDataCommand : IRequest
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? Type { get; set; }
    }

    public class DeleteDataCommandHandler : IRequestHandler<DeleteDataCommand>
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DeleteDataCommandHandler(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }
        public async Task<Unit> Handle(DeleteDataCommand request, CancellationToken cancellationToken)
        {

            await _documentTypeService.DeleteData(request);
            return Unit.Value;
        }
    }
}
