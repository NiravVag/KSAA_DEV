using AutoMapper;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using KSAA.Master.Application.DTOs.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GLIncome.Queries.ControlSheetGLSL
{
    public class GetSLMonthYearQuery : IRequest<Response<CommonRequestViewModel>>
    {
    }

    public class GetMonthYearQueryHandler : IRequestHandler<GetSLMonthYearQuery, Response<CommonRequestViewModel>>
    {
        private readonly IGLIncomeService _glIncomeService;
        private readonly IMapper _mapper;

        public GetMonthYearQueryHandler(IGLIncomeService glIncomeService, IMapper mapper)
        {
            _glIncomeService = glIncomeService;
            _mapper = mapper;
        }
        public async Task<Response<CommonRequestViewModel>> Handle(GetSLMonthYearQuery request, CancellationToken cancellationToken)
        {
            var monthyearList = await _glIncomeService.GetSLMonthYearList();

            return new Response<CommonRequestViewModel>(monthyearList);
        }
    }
}
