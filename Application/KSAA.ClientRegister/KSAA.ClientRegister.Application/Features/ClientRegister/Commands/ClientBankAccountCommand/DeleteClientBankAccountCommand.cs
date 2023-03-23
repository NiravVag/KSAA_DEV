using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand
{
    public class DeleteClientBankAccountCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteClientBankAccountCommandHandler : IRequestHandler<DeleteClientBankAccountCommand>
    {
        private readonly IClientBankAccountService _ClientBankAccountService;
        public DeleteClientBankAccountCommandHandler(IClientBankAccountService ClientBankAccountService)
        {
            _ClientBankAccountService = ClientBankAccountService;
        }

        public async Task<Unit> Handle(DeleteClientBankAccountCommand request, CancellationToken cancellationToken)
        {
            await _ClientBankAccountService.DeleteClientBankAccount(request);
            return Unit.Value;
        }
    }
}