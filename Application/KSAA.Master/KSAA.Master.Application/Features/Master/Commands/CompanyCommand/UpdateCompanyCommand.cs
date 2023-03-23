using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.CompanyCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.CompanyCommand
{
    public class UpdateCompanyCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Company_Code { get; set; }
        public string? Company_Name { get; set; }
        public string? Location { get; set; }
        public string? Company_Address { get; set; }
       /* public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}
public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Response>
{
    private readonly ICompanyService _CompanyService;
    private readonly IMapper _mapper;

    public UpdateCompanyCommandHandler(ICompanyService CompanyService, IMapper mapper)
    {
        _CompanyService = CompanyService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        await _CompanyService.EditCompany(request);

        return new Response("Company Updated Successfully");
    }
}