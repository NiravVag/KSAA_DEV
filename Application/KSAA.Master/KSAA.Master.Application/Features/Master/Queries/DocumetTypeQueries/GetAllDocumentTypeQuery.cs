using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
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
    public class GetAllDocumentTypeQuery : IRequest<Response<IEnumerable<DocumentTypeListModel>>>
    {
    }

    public class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, Response<IEnumerable<DocumentTypeListModel>>>
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public GetAllDocumentTypeQueryHandler(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<DocumentTypeListModel>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var documentTypeList = await _documentTypeService.GetDocumentTypeList();

            return new Response<IEnumerable<DocumentTypeListModel>>(documentTypeList);
        }
    }
}