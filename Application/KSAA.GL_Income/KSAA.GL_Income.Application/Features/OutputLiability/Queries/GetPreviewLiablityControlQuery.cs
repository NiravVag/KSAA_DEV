using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.OutputLiability.Queries
{
    public class GetPreviewLiablityControlQuery : IRequest<Response<IEnumerable<OutputSupplyViewModel>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class GetPreviewLiablityControlQueryHandler : IRequestHandler<GetPreviewLiablityControlQuery, Response<IEnumerable<OutputSupplyViewModel>>>
    {
        private readonly IOutputLiabilityService _outputLiabilityService;

        public GetPreviewLiablityControlQueryHandler(IOutputLiabilityService outputLiabilityService)
        {
            _outputLiabilityService = outputLiabilityService;
        }
        public async Task<Response<IEnumerable<OutputSupplyViewModel>>> Handle(GetPreviewLiablityControlQuery request, CancellationToken cancellationToken)
        {
            var documentTypeUploadList = await _outputLiabilityService.GetPreViewDocumentList(request.Month, request.Year);
            return new Response<IEnumerable<OutputSupplyViewModel>>(documentTypeUploadList);
        }
    }
}
