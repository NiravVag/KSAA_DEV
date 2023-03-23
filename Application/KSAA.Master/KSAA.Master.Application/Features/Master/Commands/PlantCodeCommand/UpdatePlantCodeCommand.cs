using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand
{
    public class UpdatePlantCodeCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? Plant_Code { get; set; }
        public string? GSTRegistrationNo { get; set; }
        public string? TypeOfUnit { get; set; }
        public string? ProductsManufactured { get; set; }
        public string? ProductsTraded { get; set; }
        public string? ServicesProvided { get; set; }
        public string? RegistrationType { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }
   
}
public class UpdatePlantCodeCommandHandler : IRequestHandler<UpdatePlantCodeCommand, Response>
{
    private readonly IPlantCodeService _PlantCodeService;
    private readonly IMapper _mapper;

    public UpdatePlantCodeCommandHandler(IPlantCodeService PlantCodeService, IMapper mapper)
    {
        _PlantCodeService = PlantCodeService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdatePlantCodeCommand request, CancellationToken cancellationToken)
    {
        await _PlantCodeService.EditPlantCode(request);

        return new Response("PlantCode Updated Successfully");
    }
}