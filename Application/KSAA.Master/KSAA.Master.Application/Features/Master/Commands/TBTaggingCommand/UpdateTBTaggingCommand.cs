using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand
{
    public class UpdateTBTaggingCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public string? TBTaggingCode { get; set; }
        public string? GLCode { get; set; }
        public string? GLName { get; set; }
        public decimal Amount { get; set; }
        public string? TagCode { get; set; }
        /*public string? IP { get; set; }
        public string? BrowserCase { get; set; }*/
        public IsActive IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UpdateTBTaggingCommandHandler : IRequestHandler<UpdateTBTaggingCommand, Response>
    {
        private readonly ITBTaggingService _TBTaggingService;
        private readonly IMapper _mapper;

        public UpdateTBTaggingCommandHandler(ITBTaggingService TBTaggingService, IMapper mapper)
        {
            _TBTaggingService = TBTaggingService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateTBTaggingCommand request, CancellationToken cancellationToken)
        {
            await _TBTaggingService.EditTBTagging(request);

            return new Response("TBTagging Updated Successfully");
        }
    }
}

