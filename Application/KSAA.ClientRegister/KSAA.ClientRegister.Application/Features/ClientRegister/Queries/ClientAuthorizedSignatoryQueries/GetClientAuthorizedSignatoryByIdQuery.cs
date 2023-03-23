using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
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
    public class GetClientAuthorizedSignatoryByIdQuery : IRequest<Response<ClientAuthorizedSignatoryViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetClientAuthorizedSignatoryByIdQueryHandler : IRequestHandler<GetClientAuthorizedSignatoryByIdQuery, Response<ClientAuthorizedSignatoryViewModel>>
    {
        private readonly IClientAuthorizedSignatoryService _ClientAuthorizedSignatoryService;
        private readonly IMapper _mapper;

        public GetClientAuthorizedSignatoryByIdQueryHandler(IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService, IMapper mapper)
        {
            _ClientAuthorizedSignatoryService = ClientAuthorizedSignatoryService;
            _mapper = mapper;
        }
        public async Task<Response<ClientAuthorizedSignatoryViewModel>> Handle(GetClientAuthorizedSignatoryByIdQuery request, CancellationToken cancellationToken)
        {
            var getClientAuthorizedSignatoryListById = await _ClientAuthorizedSignatoryService.GetClientAuthorizedSignatoryById(request.Id);
            return new Response<ClientAuthorizedSignatoryViewModel>(getClientAuthorizedSignatoryListById);
        }
    }
}