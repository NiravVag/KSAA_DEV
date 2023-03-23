using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.LocationCommand
{
    public class DeleteLocationCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly ILocationService _LocationService;
        public DeleteLocationCommandHandler(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            await _LocationService.DeleteLocation(request);
            return Unit.Value;

        }
    }
}
