using KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand
{
    public class CreatePlantCodeCommand : IRequest<Response>
    {
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Plant_Code { get; set; }
        [Required]
        public string? GSTRegistrationNo { get; set; }
        [Required]
        public string? TypeOfUnit { get; set; }
        [Required]
        public string? ProductsManufactured { get; set; }
        [Required]
        public string? ProductsTraded { get; set; }
        [Required]
        public string? ServicesProvided { get; set; }
        [Required]
        public string? RegistrationType { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class PlantCodeCommandHandler : IRequestHandler<CreatePlantCodeCommand, Response>
{
    private readonly IPlantCodeService _PlantCodeService;
    public PlantCodeCommandHandler(IPlantCodeService PlantCodeService)
    {
        _PlantCodeService = PlantCodeService;
    }
    public async Task<Response> Handle(CreatePlantCodeCommand request, CancellationToken cancellationToken)
    {
        var documentObject = await _PlantCodeService.AddPlantCode(request);
        return new Response("Plant Code Add Successfully");
    }
}