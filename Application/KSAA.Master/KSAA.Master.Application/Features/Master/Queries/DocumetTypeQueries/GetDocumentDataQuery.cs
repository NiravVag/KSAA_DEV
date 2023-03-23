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
    public class GetDocumentDataQuery : IRequest<Response<long>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? Type { get; set; }
    }

    public class GetDocumentDataQueryHandler : IRequestHandler<GetDocumentDataQuery, Response<long>>
    {
        private readonly IDocumentTypeService _documentTypeUploadService;
        private readonly IMapper _mapper;

        public GetDocumentDataQueryHandler(IDocumentTypeService documentTypeUploadService, IMapper mapper)
        {
            _documentTypeUploadService = documentTypeUploadService;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(GetDocumentDataQuery request, CancellationToken cancellationToken)
        {
            var documentData = await _documentTypeUploadService.GetDocumentData(request.Month, request.Year, request.Type);
            return new Response<long>(documentData);
        }
    }
}
