using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.CustomerCodeCommand
{
    public class UpdateCustomerCodeCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Customer_Code { get; set; }
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
public class UpdateCustomerCodeCommandHandler : IRequestHandler<UpdateCustomerCodeCommand, Response>
{
    private readonly ICustomerCodeService _CustomerCodeService;
    private readonly IMapper _mapper;

    public UpdateCustomerCodeCommandHandler(ICustomerCodeService CustomerCodeService, IMapper mapper)
    {
        _CustomerCodeService = CustomerCodeService;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateCustomerCodeCommand request, CancellationToken cancellationToken)
    {
        await _CustomerCodeService.EditCustomerCode(request);

        return new Response("CustomerCode Updated Successfully");
    }
}