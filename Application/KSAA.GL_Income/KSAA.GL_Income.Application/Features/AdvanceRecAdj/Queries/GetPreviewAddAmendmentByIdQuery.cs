using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.AdvanceRecAdj.Queries
{
    public class GetPreviewAddAmendmentByIdQuery : IRequest<Response<List<AdvanceAmendmentViewModel>>>
    {
        public long Id { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetPreviewAddAmendmentByIdQueryHandler : IRequestHandler<GetPreviewAddAmendmentByIdQuery, Response<List<AdvanceAmendmentViewModel>>>
    {
        private readonly IAdvaceReceivedService _advaceReceivedService;

        public GetPreviewAddAmendmentByIdQueryHandler(IAdvaceReceivedService advaceReceivedService)
        {
            _advaceReceivedService = advaceReceivedService;
        }
        public async Task<Response<List<AdvanceAmendmentViewModel>>> Handle(GetPreviewAddAmendmentByIdQuery request, CancellationToken cancellationToken)
        {
            var addAmendmentList = await _advaceReceivedService.GetPreviewAddAmendmentByIdList(request.Id, request.Month, request.Year);
            return new Response<List<AdvanceAmendmentViewModel>>(addAmendmentList);
        }
    }
}
