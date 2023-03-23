using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand
{
    public class CreateClientAuthorizedSignatoryCommand : IRequest<Response>
    {
        
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FatherFirstName { get; set; }
        public string? FatherMiddleName { get; set; }
        public string? FatherLastName { get; set; }
        public DateTime BOD { get; set; }
        public string? Gender { get; set; }
        public string? DesignationStatus { get; set; }
        public string? Mobile { get; set; }
        public string? PhoneNoSTD { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PAN { get; set; }
        public string? DIN { get; set; }
        public bool? Indian { get; set; }
        public string? Photo { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CompanyCommandHandler : IRequestHandler<CreateClientAuthorizedSignatoryCommand, Response>
{
    private readonly IClientAuthorizedSignatoryService _ClientAuthorizedSignatoryService;
    public CompanyCommandHandler(IClientAuthorizedSignatoryService ClientAuthorizedSignatoryService)
    {
        _ClientAuthorizedSignatoryService = ClientAuthorizedSignatoryService;
    }
    public async Task<Response> Handle(CreateClientAuthorizedSignatoryCommand request, CancellationToken cancellationToken)
    {
        await _ClientAuthorizedSignatoryService.AddClientAuthorizedSignatory(request);
        return new Response("Client Authorized Signatory Add Successfully");
    }
}