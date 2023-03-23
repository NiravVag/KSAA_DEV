using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand
{
    public class DeleteClientServicesGoodsCommand : IRequest
    {
        public virtual long Id { get; set; }
    }
    public class DeleteClientServicesGoodsCommandCommandHandler : IRequestHandler<DeleteClientServicesGoodsCommand>
    {
        private readonly IClientServicesGoodsService _ClientServicesGoodsService;
        public DeleteClientServicesGoodsCommandCommandHandler(IClientServicesGoodsService ClientServicesGoodsService)
        {
            _ClientServicesGoodsService = ClientServicesGoodsService;
        }

        public async Task<Unit> Handle(DeleteClientServicesGoodsCommand request, CancellationToken cancellationToken)
        {
            await _ClientServicesGoodsService.DeleteClientServicesGoods(request);
            return Unit.Value;
        }
    }
}