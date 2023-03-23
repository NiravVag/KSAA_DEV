using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand
{
    public class CreateClientRegistrationCommand : IRequest<Response>
    {

        public string? RegistrationType { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CreateClientRegistrationCommandHandler : IRequestHandler<CreateClientRegistrationCommand, Response>
{
    private readonly IClientRegistrationService _ClientRegistrationService;
    public CreateClientRegistrationCommandHandler(IClientRegistrationService ClientRegistrationService)
    {
        _ClientRegistrationService = ClientRegistrationService;
    }
    public async Task<Response> Handle(CreateClientRegistrationCommand request, CancellationToken cancellationToken)
    {
        await _ClientRegistrationService.AddClientRegistration(request);
        return new Response("Client Registration Add Successfully");
    }
}