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

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientBankAccountQueries
{
    public class GetAllClientBankAccountQuery : IRequest<Response<IEnumerable<ClientBankAccountListModel>>>
    {
    }

    public class GetAllClientBankAccountQueryHandler : IRequestHandler<GetAllClientBankAccountQuery, Response<IEnumerable<ClientBankAccountListModel>>>
    {
        private readonly IClientBankAccountService _ClientBankAccountService;
        private readonly IMapper _mapper;

        public GetAllClientBankAccountQueryHandler(IClientBankAccountService ClientBankAccountService, IMapper mapper)
        {
            _ClientBankAccountService = ClientBankAccountService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientBankAccountListModel>>> Handle(GetAllClientBankAccountQuery request, CancellationToken cancellationToken)
        {
            var ClientBankAccountList = await _ClientBankAccountService.GetClientBankAccountList();
            return new Response<IEnumerable<ClientBankAccountListModel>>(ClientBankAccountList);
        }
    }
}
