using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL
{
    public class GenControlSheetCommand : IRequest<Response<GL_IncomeListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GenControlSheetCommandHandler : IRequestHandler<GenControlSheetCommand, Response<GL_IncomeListModel>>
    {
        private readonly IGLIncomeService _glIncomeService;

        public GenControlSheetCommandHandler(IGLIncomeService glIncomeService)
        {
            _glIncomeService = glIncomeService;
        }
        public async Task<Response<GL_IncomeListModel>> Handle(GenControlSheetCommand request, CancellationToken cancellationToken)
        {
            var glIncomeGen = await _glIncomeService.GenControlSheet(request);
            return new Response<GL_IncomeListModel>(glIncomeGen);
        }
    }
}
