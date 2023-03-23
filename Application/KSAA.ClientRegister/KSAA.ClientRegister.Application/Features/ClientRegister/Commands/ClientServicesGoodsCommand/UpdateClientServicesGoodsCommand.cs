using AutoMapper;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using KSAA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand
{
    public class UpdateClientServicesGoodsCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? ServicesName { get; set; }
        public string? ServicesCode { get; set; }
        /* public string? IP { get; set; }
         public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateClientServicesGoodsCommandHandler : IRequestHandler<UpdateClientServicesGoodsCommand, Response>
{
    private readonly IClientServicesGoodsService _ClientServicesGoodsService;
    private readonly IMapper _mapper;

    public UpdateClientServicesGoodsCommandHandler(IClientServicesGoodsService ClientServicesGoodsService, IMapper mapper)
    {
        _ClientServicesGoodsService = ClientServicesGoodsService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateClientServicesGoodsCommand request, CancellationToken cancellationToken)
    {
        await _ClientServicesGoodsService.EditClientServicesGoods(request);
        return new Response("Client Services Goods Updated Successfully");
    }
}