using AutoMapper;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using KSAA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand
{
    public class UpdateClientBankAccountCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? BranchName { get; set; }
        public string? AccountNo { get; set; }
        public string? Type { get; set; }
        public string? IFSCCode { get; set; }
        public string? BankPassbookPage { get; set; }
        public string? StatementCancelledCheque { get; set; }
        /* public string? IP { get; set; }
         public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateClientBankAccountCommandHandler : IRequestHandler<UpdateClientBankAccountCommand, Response>
{
    private readonly IClientBankAccountService _ClientBankAccountService;
    private readonly IMapper _mapper;

    public UpdateClientBankAccountCommandHandler(IClientBankAccountService ClientBankAccountService, IMapper mapper)
    {
        _ClientBankAccountService = ClientBankAccountService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateClientBankAccountCommand request, CancellationToken cancellationToken)
    {
        await _ClientBankAccountService.EditClientBankAccount(request);
        return new Response("Client Bank Account Updated Successfully");
    }
}