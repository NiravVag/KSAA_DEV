using AutoMapper;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GLIncome.Queries.ControlSheetGLSL
{
    public class GetGLIncomeControlSheetQuery : IRequest<Response<GL_IncomeListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetGLIncomeControlSheetQueryHandler : IRequestHandler<GetGLIncomeControlSheetQuery, Response<GL_IncomeListModel>>
    {
        private readonly IGLIncomeService _glIncomeService;

        public GetGLIncomeControlSheetQueryHandler(IGLIncomeService glIncomeService)
        {
            _glIncomeService = glIncomeService;
        }
        public async Task<Response<GL_IncomeListModel>> Handle(GetGLIncomeControlSheetQuery request, CancellationToken cancellationToken)
        {
            var glIncomeList = await _glIncomeService.GetGLIncomeControlSheet(request.Month, request.Year);
            return new Response<GL_IncomeListModel>(glIncomeList);
        }
    }
}
