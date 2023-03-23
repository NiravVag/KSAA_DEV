using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand
{
    public class DeleteTBTaggingCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteTBTaggingCommandHandler : IRequestHandler<DeleteTBTaggingCommand>
    {
        private readonly ITBTaggingService _TBTaggingService;
        public DeleteTBTaggingCommandHandler(ITBTaggingService TBTaggingService)
        {
            _TBTaggingService = TBTaggingService;
        }

        public async Task<Unit> Handle(DeleteTBTaggingCommand request, CancellationToken cancellationToken)
        {
            await _TBTaggingService.DeleteTBTagging(request);
            return Unit.Value;

        }
    }
}