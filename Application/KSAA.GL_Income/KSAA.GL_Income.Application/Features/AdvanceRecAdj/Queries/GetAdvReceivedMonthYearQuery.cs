using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using KSAA.Master.Application.DTOs.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.AdvanceRecAdj.Queries
{
    public class GetAdvReceivedMonthYearQuery : IRequest<Response<CommonRequestViewModel>>
    {
    }
    public class GetMonthYearQueryHandler : IRequestHandler<GetAdvReceivedMonthYearQuery, Response<CommonRequestViewModel>>
    {
        private readonly IAdvaceReceivedService _advaceReceivedService;

        public GetMonthYearQueryHandler(IAdvaceReceivedService advaceReceivedService)
        {
            _advaceReceivedService = advaceReceivedService;
        }
        public async Task<Response<CommonRequestViewModel>> Handle(GetAdvReceivedMonthYearQuery request, CancellationToken cancellationToken)
        {
            var monthyearList = await _advaceReceivedService.GetAdvReceivedMonthYearList();

            return new Response<CommonRequestViewModel>(monthyearList);
        }
    }
}
