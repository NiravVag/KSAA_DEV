using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand
{
    public class CreateTBTaggingCommand : IRequest<Response>
    {
        [Required]
        public virtual string? TBTaggingCode { get; set; }
        [Required]
        public virtual string? GLCode { get; set; }
        [Required]
        public virtual string? GLName { get; set; }
        [Required]
        public virtual decimal Amount { get; set; }
        [Required]
        public virtual string? TagCode { get; set; }
        /*[Required]
        public virtual string? IP { get; set; }
        [Required]
        public virtual string? BrowserCase { get; set; }*/
    }

    public class CreateTBTaggingCommandHandler : IRequestHandler<CreateTBTaggingCommand, Response>
    {
        private readonly ITBTaggingService _TBTaggingService;
        public CreateTBTaggingCommandHandler(ITBTaggingService TBTaggingService)
        {
            _TBTaggingService = TBTaggingService;
        }
        public async Task<Response> Handle(CreateTBTaggingCommand request, CancellationToken cancellationToken)
        {

            var documentObject = await _TBTaggingService.AddTBTagging(request);
            return new Response("TBTagging Add Successfully");
        }
    }
}