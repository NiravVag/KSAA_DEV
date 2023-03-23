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
    public class GetAllAdvanceReceivedModuleQuery : IRequest<Response<AdvanceReceivedListModule>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetAllAdvanceReceivedModuleQueryHandler : IRequestHandler<GetAllAdvanceReceivedModuleQuery, Response<AdvanceReceivedListModule>>
    {
        private readonly IAdvaceReceivedService _advaceReceivedService;

        public GetAllAdvanceReceivedModuleQueryHandler(IAdvaceReceivedService advaceReceivedService)
        {
            _advaceReceivedService = advaceReceivedService;
        }
        public async Task<Response<AdvanceReceivedListModule>> Handle(GetAllAdvanceReceivedModuleQuery request, CancellationToken cancellationToken)
        {
            var advaceReceivedList = await _advaceReceivedService.GetAdvaceReceivedModuleList(request.Month, request.Year);
            return new Response<AdvanceReceivedListModule>(advaceReceivedList);
        }
    }
}
