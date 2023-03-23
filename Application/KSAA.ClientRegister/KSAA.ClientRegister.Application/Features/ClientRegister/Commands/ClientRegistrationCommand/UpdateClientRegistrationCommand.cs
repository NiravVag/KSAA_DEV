using AutoMapper;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using KSAA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand
{
    public class UpdateClientRegistrationCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? RegistrationType { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        /* public string? IP { get; set; }
         public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateClientRegistrationCommandHandler : IRequestHandler<UpdateClientRegistrationCommand, Response>
{
    private readonly IClientRegistrationService _ClientRegistrationService;
    private readonly IMapper _mapper;

    public UpdateClientRegistrationCommandHandler(IClientRegistrationService ClientRegistrationService, IMapper mapper)
    {
        _ClientRegistrationService = ClientRegistrationService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateClientRegistrationCommand request, CancellationToken cancellationToken)
    {
        await _ClientRegistrationService.EditClientRegistration(request);
        return new Response("Client Registration Updated Successfully");
    }
}