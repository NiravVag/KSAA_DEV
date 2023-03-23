using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand
{
    public class DeleteClientRegistrationCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteClientRegistrationCommandHandler : IRequestHandler<DeleteClientRegistrationCommand>
    {
        private readonly IClientRegistrationService _ClientRegistrationService;
        public DeleteClientRegistrationCommandHandler(IClientRegistrationService ClientRegistrationService)
        {
            _ClientRegistrationService = ClientRegistrationService;
        }

        public async Task<Unit> Handle(DeleteClientRegistrationCommand request, CancellationToken cancellationToken)
        {
            await _ClientRegistrationService.DeleteClientRegistration(request);
            return Unit.Value;
        }
    }
}