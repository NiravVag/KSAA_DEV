using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.LocationCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.LocationCommand
{
    public class UpdateLocationCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Location_Code { get; set; }
        public string? Address { get; set; }
        public string? GSTRegistrationNo { get; set; }
        public string? TypeOfUnit { get; set; }
        public string? ProductsManufactured { get; set; }
        public string? ProductsTraded { get; set; }
        public string? TypeOfServicesProvided { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response>
{
    private readonly ILocationService _LocationService;
    private readonly IMapper _mapper;

    public UpdateLocationCommandHandler(ILocationService LocationService, IMapper mapper)
    {
        _LocationService = LocationService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        await _LocationService.EditLocation(request);

        return new Response("Location Updated Successfully");
    }
}
