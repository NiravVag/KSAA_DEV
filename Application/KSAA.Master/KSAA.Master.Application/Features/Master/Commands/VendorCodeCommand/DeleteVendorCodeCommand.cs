using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand
{
    public class DeleteVendorCodeCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteVendorCodeCommandHandler : IRequestHandler<DeleteVendorCodeCommand>
    {
        private readonly IVendorCodeService _VendorCodeService;
        public DeleteVendorCodeCommandHandler(IVendorCodeService VendorCodeService)
        {
            _VendorCodeService = VendorCodeService;
        }

        public async Task<Unit> Handle(DeleteVendorCodeCommand request, CancellationToken cancellationToken)
        {
            await _VendorCodeService.DeleteVendorCode(request);
            return Unit.Value;

        }
    }
}