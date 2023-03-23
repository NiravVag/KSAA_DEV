using KSAA.Master.Application.Features.Master.Commands.LocationCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.LocationCommand
{
    public class CreateLocationCommand : IRequest<Response>
    {
        [Required]
        public string? Location_Code { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? GSTRegistrationNo { get; set; }
        [Required]
        public string? TypeOfUnit { get; set; }
        [Required]
        public string? ProductsManufactured { get; set; }
        [Required]
        public string? ProductsTraded { get; set; }
        [Required]
        public string? TypeOfServicesProvided { get; set; }
       /* [Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class LocationCommandHandler : IRequestHandler<CreateLocationCommand, Response>
{
    private readonly ILocationService _LocationService;
    public LocationCommandHandler(ILocationService LocationService)
    {
        _LocationService = LocationService;
    }
    public async Task<Response> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var documentObject = await _LocationService.AddLocation(request);
        return new Response("Location Add Successfully");
    }
}
