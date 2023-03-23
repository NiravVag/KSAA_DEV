using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Commands.TaxCodeCommand
{
    public class DeleteTaxCodeCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeletePlantCodeCommandHandler : IRequestHandler<DeleteTaxCodeCommand>
    {
        private readonly ITaxCodeService _taxCodeService;
        public DeletePlantCodeCommandHandler(ITaxCodeService taxCodeService)
        {
            _taxCodeService = taxCodeService;
        }

        public async Task<Unit> Handle(DeleteTaxCodeCommand request, CancellationToken cancellationToken)
        {
            await _taxCodeService.DeleteTaxCode(request);
            return Unit.Value;

        }
    }
}