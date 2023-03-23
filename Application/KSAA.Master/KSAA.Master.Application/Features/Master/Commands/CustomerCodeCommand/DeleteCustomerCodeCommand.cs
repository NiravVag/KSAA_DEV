using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand
{
    public class DeleteCustomerCodeCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteCustomerCodeCommandHandler : IRequestHandler<DeleteCustomerCodeCommand>
    {
        private readonly ICustomerCodeService _CustomerCodeService;
        public DeleteCustomerCodeCommandHandler(ICustomerCodeService customerCodeService)
        {
            _CustomerCodeService = customerCodeService;
        }

        public async Task<Unit> Handle(DeleteCustomerCodeCommand request, CancellationToken cancellationToken)
        {
            await _CustomerCodeService.DeleteCustomerCode(request);
            return Unit.Value;

        }
    }
}