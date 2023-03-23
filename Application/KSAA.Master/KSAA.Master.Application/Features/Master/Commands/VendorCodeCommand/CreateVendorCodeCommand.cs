using KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand
{
    public class CreateVendorCodeCommand : IRequest<Response>
    {
        [Required]
        public string? Vendor_Code { get; set; }
        [Required]
        public string? GSTN { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Address { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class VendorCodeCommandHandler : IRequestHandler<CreateVendorCodeCommand, Response>
{
    private readonly IVendorCodeService _VendorCodeService;
    public VendorCodeCommandHandler(IVendorCodeService VendorCodeService)
    {
        _VendorCodeService = VendorCodeService;
    }
    public async Task<Response> Handle(CreateVendorCodeCommand request, CancellationToken cancellationToken)
    {
        var documentObject = await _VendorCodeService.AddVendorCode(request);
        return new Response("Vendor Code Add Successfully");
    }
}