using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.VendorCodeCommand
{
    public class UpdateVendorCodeCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Vendor_Code { get; set; }
        public string? GSTN { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateVendorCodeCommandHandler : IRequestHandler<UpdateVendorCodeCommand, Response>
{
    private readonly IVendorCodeService _VendorCodeService;
    private readonly IMapper _mapper;

    public UpdateVendorCodeCommandHandler(IVendorCodeService VendorCodeService, IMapper mapper)
    {
        _VendorCodeService = VendorCodeService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateVendorCodeCommand request, CancellationToken cancellationToken)
    {
        await _VendorCodeService.EditVendorCode(request);

        return new Response("VendorCode Updated Successfully");
    }
}