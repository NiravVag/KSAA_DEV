using KSAA.Master.Application.Features.Master.Commands.CompanyCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.CompanyCommand
{
    public class CreateCompanyCommand : IRequest<Response>
    {
        [Required]
        public string? Company_Code { get; set; }
        [Required]
        public string? Company_Name { get; set; }
        [Required]
        public string? Company_Address { get; set; }
        /*[Required]
        public string? IP { get; set; }
        [Required]
        public string? BrowserCase { get; set; }*/
    }
}

public class CompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response>
{
    private readonly ICompanyService _CompanyService;
    public CompanyCommandHandler(ICompanyService CompanyService)
    {
        _CompanyService = CompanyService;
    }
    public async Task<Response> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var documentObject = await _CompanyService.AddCompany(request);
        return new Response("Company Add Successfully");
    }
}