using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand
{
    public class CreateClientManagingDirectorCommand : IRequest<Response>
    {

        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public DateTime BOD { get; set; }
        public string? DesignationStatus { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNoSTD { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PAN { get; set; }
        public string? DIN { get; set; }
        //public string? Indian { get; set; }
        public string? Photo { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CreateClientManagingDirectorCommandHandler : IRequestHandler<CreateClientManagingDirectorCommand, Response>
{
    private readonly IClientManagingDirectorService _ClientManagingDirectorService;
    public CreateClientManagingDirectorCommandHandler(IClientManagingDirectorService ClientManagingDirectorService)
    {
        _ClientManagingDirectorService = ClientManagingDirectorService;
    }
    public async Task<Response> Handle(CreateClientManagingDirectorCommand request, CancellationToken cancellationToken)
    {
        await _ClientManagingDirectorService.AddClientManagingDirector(request);
        return new Response("Client Managing Director Add Successfully");
    }
}