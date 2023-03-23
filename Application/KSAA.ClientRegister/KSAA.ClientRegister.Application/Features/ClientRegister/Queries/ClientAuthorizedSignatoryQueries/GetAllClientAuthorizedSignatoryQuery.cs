using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientAuthorizedSignatoryQueries
{
    public class GetAllClientAuthorizedSignatoryQuery : IRequest<Response<IEnumerable<ClientAuthorizedSignatoryListModel>>>
    {
    }

    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllClientAuthorizedSignatoryQuery, Response<IEnumerable<ClientAuthorizedSignatoryListModel>>>
    {
        private readonly IClientAuthorizedSignatoryService _ClientAuthorizedSignatoryService;
        private readonly IMapper _mapper;

        public GetAllCompanyQueryHandler(IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService, IMapper mapper)
        {
            _ClientAuthorizedSignatoryService = ClientAuthorizedSignatoryService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientAuthorizedSignatoryListModel>>> Handle(GetAllClientAuthorizedSignatoryQuery request, CancellationToken cancellationToken)
        {
            var ClientAuthorizedSignatoryList = await _ClientAuthorizedSignatoryService.GetClientAuthorizedSignatoryList();

            return new Response<IEnumerable<ClientAuthorizedSignatoryListModel>>(ClientAuthorizedSignatoryList);
        }
    }
}
