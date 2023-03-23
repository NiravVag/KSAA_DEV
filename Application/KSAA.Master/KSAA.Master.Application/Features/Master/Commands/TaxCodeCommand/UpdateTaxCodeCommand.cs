using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Commands.TaxCodeCommand
{
    public class UpdateTaxCodeCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? Tax_Code { get; set; }
        public string? SubtaxName { get; set; }
        public int TaxRate { get; set; }
        public string? Type { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }
    public class UpdateTaxCodeCommandHandler : IRequestHandler<UpdateTaxCodeCommand, Response>
    {
        private readonly ITaxCodeService _taxCodeService;
        private readonly IMapper _mapper;

        public UpdateTaxCodeCommandHandler(ITaxCodeService taxCodeService, IMapper mapper)
        {
            _taxCodeService = taxCodeService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateTaxCodeCommand request, CancellationToken cancellationToken)
        {
            await _taxCodeService.EditTaxCode(request);

            return new Response("TaxCode Updated Successfully");
        }
    }
}