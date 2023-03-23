using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientAuthorizedSignatoryQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientRegistrationQueries
{
    public class GetClientRegistrationByIdQuery : IRequest<Response<ClientRegistrationViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetClientRegistrationByIdQueryHandler : IRequestHandler<GetClientRegistrationByIdQuery, Response<ClientRegistrationViewModel>>
    {
        private readonly IClientRegistrationService _ClientRegistrationService;
        private readonly IMapper _mapper;

        public GetClientRegistrationByIdQueryHandler(IClientRegistrationService ClientRegistrationService, IMapper mapper)
        {
            _ClientRegistrationService = ClientRegistrationService;
            _mapper = mapper;
        }
        public async Task<Response<ClientRegistrationViewModel>> Handle(GetClientRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            var getClientRegistrationById = await _ClientRegistrationService.GetClientRegistrationById(request.Id);
            return new Response<ClientRegistrationViewModel>(getClientRegistrationById);
        }
    }
}