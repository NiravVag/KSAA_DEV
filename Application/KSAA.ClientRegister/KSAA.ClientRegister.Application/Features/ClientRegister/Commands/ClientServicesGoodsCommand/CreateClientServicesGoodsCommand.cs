using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand
{
    public class CreateClientServicesGoodsCommand : IRequest<Response>
    {
        public string? ServicesName { get; set; }
        public string? ServicesCode { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CreateClientServicesGoodsCommandHandler : IRequestHandler<CreateClientServicesGoodsCommand, Response>
{
    private readonly IClientServicesGoodsService _ClientServicesGoodsService;
    public CreateClientServicesGoodsCommandHandler(IClientServicesGoodsService ClientServicesGoodsService)
    {
        _ClientServicesGoodsService = ClientServicesGoodsService;
    }
    public async Task<Response> Handle(CreateClientServicesGoodsCommand request, CancellationToken cancellationToken)
    {
        await _ClientServicesGoodsService.AddClientServicesGoods(request);
        return new Response("Client Services Goods Add Successfully");
    }
}