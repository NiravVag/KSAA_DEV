using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.OutputLiability.Commands
{
    public class AddToSupplyOutputLiabliyCommand : IRequest<Response<OutputLiabilityListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class AddToSupplyCommandHandler : IRequestHandler<AddToSupplyOutputLiabliyCommand, Response<OutputLiabilityListModel>>
    {
        private readonly IOutputLiabilityService _outputLiabilityService;

        public AddToSupplyCommandHandler(IOutputLiabilityService outputLiabilityService)
        {
            _outputLiabilityService = outputLiabilityService;
        }
        public async Task<Response<OutputLiabilityListModel>> Handle(AddToSupplyOutputLiabliyCommand request, CancellationToken cancellationToken)
        {
            var outputLiablity = await _outputLiabilityService.AddInSupply(request);
            return new Response<OutputLiabilityListModel>(outputLiablity);
        }
    }
}
