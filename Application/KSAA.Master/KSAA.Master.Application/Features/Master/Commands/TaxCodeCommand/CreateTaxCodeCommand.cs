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
    public class CreateTaxCodeCommand : IRequest<Response>
    {
        [Required]
        public virtual string? SubtaxName { get; set; }
        [Required]
        public virtual int TaxRate { get; set; }
        [Required]
        public virtual string? Tax_Code { get; set; }
        [Required]
        public virtual string? Type { get; set; }
        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/

    }

    public class CreateTaxCodeCommandHandler : IRequestHandler<CreateTaxCodeCommand, Response>
    {
        private readonly ITaxCodeService _plantCodeService;
        public CreateTaxCodeCommandHandler(ITaxCodeService plantCodeService)
        {
            _plantCodeService = plantCodeService;
        }
        public async Task<Response> Handle(CreateTaxCodeCommand request, CancellationToken cancellationToken)
        {
            var documentObject = await _plantCodeService.AddTaxCode(request);
            return new Response("Tax Code Add Successfully");
        }
    }
}