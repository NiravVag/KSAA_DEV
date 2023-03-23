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

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientBankAccountQueries
{
    public class GetClientBankAccountByIdQuery : IRequest<Response<ClientBankAccountViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetClientBankAccountByIdQueryHandler : IRequestHandler<GetClientBankAccountByIdQuery, Response<ClientBankAccountViewModel>>
    {
        private readonly IClientBankAccountService _ClientBankAccountService;
        private readonly IMapper _mapper;

        public GetClientBankAccountByIdQueryHandler(IClientBankAccountService ClientBankAccountService, IMapper mapper)
        {
            _ClientBankAccountService = ClientBankAccountService;
            _mapper = mapper;
        }
        public async Task<Response<ClientBankAccountViewModel>> Handle(GetClientBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var getClientBankAccountById = await _ClientBankAccountService.GetClientBankAccountById(request.Id);
            return new Response<ClientBankAccountViewModel>(getClientBankAccountById);
        }
    }
}