using KSAA.GL_Income.Application.DTOs.GLIncome;
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
    public class GenLiabilityControlSheetCommand : IRequest<Response<OutputLiabilityListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GenLiabilityControlSheetCommandHandler : IRequestHandler<GenLiabilityControlSheetCommand, Response<OutputLiabilityListModel>>
    {
        private readonly IOutputLiabilityService _outputLiabilityService;

        public GenLiabilityControlSheetCommandHandler(IOutputLiabilityService outputLiabilityService)
        {
            _outputLiabilityService = outputLiabilityService;
        }
        public async Task<Response<OutputLiabilityListModel>> Handle(GenLiabilityControlSheetCommand request, CancellationToken cancellationToken)
        {
            var outputLiabilityGen = await _outputLiabilityService.GenLiabilityControlSheet(request);
            return new Response<OutputLiabilityListModel>(outputLiabilityGen);
        }
    }
}
