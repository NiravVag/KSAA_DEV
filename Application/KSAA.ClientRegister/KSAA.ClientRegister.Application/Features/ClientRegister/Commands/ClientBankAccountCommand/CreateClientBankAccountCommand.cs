using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand
{
    public class CreateClientBankAccountCommand : IRequest<Response>
    {
        public string? BranchName { get; set; }
        public string? AccountNo { get; set; }
        public string? Type { get; set; }
        public string? IFSCCode { get; set; }
        public string? BankPassbookPage { get; set; }
        public string? StatementCancelledCheque { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CreateClientBankAccountCommandHandler : IRequestHandler<CreateClientBankAccountCommand, Response>
{
    private readonly IClientBankAccountService _ClientBankAccountService;
    public CreateClientBankAccountCommandHandler(IClientBankAccountService ClientBankAccountService)
    {
        _ClientBankAccountService = ClientBankAccountService;
    }
    public async Task<Response> Handle(CreateClientBankAccountCommand request, CancellationToken cancellationToken)
    {
        await _ClientBankAccountService.AddClientBankAccount(request);
        return new Response("Client Bank Account Add Successfully");
    }
}