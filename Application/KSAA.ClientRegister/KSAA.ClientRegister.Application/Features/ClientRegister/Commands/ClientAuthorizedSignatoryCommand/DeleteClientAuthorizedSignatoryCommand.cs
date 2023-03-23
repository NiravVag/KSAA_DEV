using KSAA.ClientRegister.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand
{
    public class DeleteClientAuthorizedSignatoryCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteClientAuthorizedSignatoryCommandHandler : IRequestHandler<DeleteClientAuthorizedSignatoryCommand>
    {
        private readonly IClientAuthorizedSignatoryService _ClientAuthorizedSignatoryService;
        public DeleteClientAuthorizedSignatoryCommandHandler(IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService)
        {
            _ClientAuthorizedSignatoryService = ClientAuthorizedSignatoryService;
        }

        public async Task<Unit> Handle(DeleteClientAuthorizedSignatoryCommand request, CancellationToken cancellationToken)
        {
            await _ClientAuthorizedSignatoryService.DeleteClientAuthorizedSignatory(request);
            return Unit.Value;
        }
    }
}