using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand
{
    public class DeletePlantCodeCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeletePlantCodeCommandHandler : IRequestHandler<DeletePlantCodeCommand>
    {
        private readonly IPlantCodeService _PlantCodeService;
        public DeletePlantCodeCommandHandler(IPlantCodeService PlantCodeService)
        {
            _PlantCodeService = PlantCodeService;
        }

        public async Task<Unit> Handle(DeletePlantCodeCommand request, CancellationToken cancellationToken)
        {
            await _PlantCodeService.DeletePlantCode(request);
            return Unit.Value;

        }
    }
}