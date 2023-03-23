using AutoMapper;
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
    public class GetPreviewDocumentUploadQuery : IRequest<Response<object>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? Type { get; set; }
    }
    public class GetPreviewDocumentUploadQueryHandler : IRequestHandler<GetPreviewDocumentUploadQuery, Response<object>>
    {
        private readonly IDocumentTypeService _documentTypeUploadService;
        private readonly IMapper _mapper;

        public GetPreviewDocumentUploadQueryHandler(IDocumentTypeService documentTypeUploadService, IMapper mapper)
        {
            _documentTypeUploadService = documentTypeUploadService;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle(GetPreviewDocumentUploadQuery request, CancellationToken cancellationToken)
        {
            var documentTypeUploadList = await _documentTypeUploadService.GetPreViewDocumentList(request.Month, request.Year, request.Type);
            return new Response<object>(documentTypeUploadList);
        }
    }
}
