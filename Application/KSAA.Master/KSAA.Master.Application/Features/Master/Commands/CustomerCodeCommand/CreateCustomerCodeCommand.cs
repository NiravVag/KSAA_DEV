using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
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

namespace KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand
{
    public class CreateCustomerCodeCommand : IRequest<Response>
    {
        [Required]
        public string? Customer_Code { get; set; }
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

public class CustomerCodeCommandHandler : IRequestHandler<CreateCustomerCodeCommand, Response>
{
    private readonly ICustomerCodeService _CustomerCodeService;
    public CustomerCodeCommandHandler(ICustomerCodeService CustomerCodeService)
    {
        _CustomerCodeService = CustomerCodeService;
    }
    public async Task<Response> Handle(CreateCustomerCodeCommand request, CancellationToken cancellationToken)
    {
        var documentObject = await _CustomerCodeService.AddCustomerCode(request);
        return new Response("Customer Code Add Successfully");
    }
}