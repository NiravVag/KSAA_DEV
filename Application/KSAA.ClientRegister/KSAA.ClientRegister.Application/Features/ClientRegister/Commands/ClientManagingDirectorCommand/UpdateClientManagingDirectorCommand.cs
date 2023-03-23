using AutoMapper;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using KSAA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand
{
    public class UpdateClientManagingDirectorCommand : IRequest<Response>
    {
        public long Id { get; set; }
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
        /* public string? IP { get; set; }
         public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateClientManagingDirectorCommandHandler : IRequestHandler<UpdateClientManagingDirectorCommand, Response>
{
    IClientManagingDirectorService _ClientManagingDirectorService;
    private readonly IMapper _mapper;

    public UpdateClientManagingDirectorCommandHandler(IClientManagingDirectorService ClientManagingDirectorService, IMapper mapper)
    {
        _ClientManagingDirectorService = ClientManagingDirectorService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateClientManagingDirectorCommand request, CancellationToken cancellationToken)
    {
        await _ClientManagingDirectorService.EditClientManagingDirector(request);
        return new Response("Client Managing Director Updated Successfully");
    }
}