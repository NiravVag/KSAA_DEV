using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Queries.DocumetTypeQueries
{
    public class GetDocumentTypeByIdQuery : IRequest<Response<DocumentTypeViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetDocumentTypeByIdQueryHandler : IRequestHandler<GetDocumentTypeByIdQuery, Response<DocumentTypeViewModel>>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public GetDocumentTypeByIdQueryHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }
        public async Task<Response<DocumentTypeViewModel>> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var gedocumentTypeById = await _documentTypeService.GetDocumentTypeById(request.Id);
            return new Response<DocumentTypeViewModel>(gedocumentTypeById);
        }
    }
}
