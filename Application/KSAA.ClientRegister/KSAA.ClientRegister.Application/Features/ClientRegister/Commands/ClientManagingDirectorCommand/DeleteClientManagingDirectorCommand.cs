using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand
{
    public class DeleteClientManagingDirectorCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteClientManagingDirectorCommandHandler : IRequestHandler<DeleteClientManagingDirectorCommand>
    {
        private readonly IClientManagingDirectorService _ClientManagingDirectorService;
        public DeleteClientManagingDirectorCommandHandler(IClientManagingDirectorService ClientManagingDirectorService)
        {
            _ClientManagingDirectorService = ClientManagingDirectorService;
        }

        public async Task<Unit> Handle(DeleteClientManagingDirectorCommand request, CancellationToken cancellationToken)
        {
            await _ClientManagingDirectorService.DeleteClientManagingDirector(request);
            return Unit.Value;
        }
    }
}