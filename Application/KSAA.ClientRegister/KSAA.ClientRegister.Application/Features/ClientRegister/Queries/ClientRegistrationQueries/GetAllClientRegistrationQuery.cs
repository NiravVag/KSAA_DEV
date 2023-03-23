using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
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
    public class GetAllClientRegistrationQuery : IRequest<Response<IEnumerable<ClientRegistrationListModel>>>
    {
    }

    public class GetAllClientRegistrationQueryHandler : IRequestHandler<GetAllClientRegistrationQuery, Response<IEnumerable<ClientRegistrationListModel>>>
    {
        private readonly IClientRegistrationService _ClientRegistrationService;
        private readonly IMapper _mapper;

        public GetAllClientRegistrationQueryHandler(IClientRegistrationService ClientRegistrationService, IMapper mapper)
        {
            _ClientRegistrationService = ClientRegistrationService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientRegistrationListModel>>> Handle(GetAllClientRegistrationQuery request, CancellationToken cancellationToken)
        {
            var ClientRegistrationList = await _ClientRegistrationService.GetClientRegistrationList();

            return new Response<IEnumerable<ClientRegistrationListModel>>(ClientRegistrationList);
        }
    }
}
