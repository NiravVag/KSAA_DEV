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
    public class AddToSupplyCommand : IRequest<Response<GL_IncomeListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class AddToSupplyCommandHandler : IRequestHandler<AddToSupplyCommand, Response<GL_IncomeListModel>>
    {
        private readonly IGLIncomeService _glIncomeService;

        public AddToSupplyCommandHandler(IGLIncomeService glIncomeService)
        {
            _glIncomeService = glIncomeService;
        }
        public async Task<Response<GL_IncomeListModel>> Handle(AddToSupplyCommand request, CancellationToken cancellationToken)
        {
            var glIncomeGen = await _glIncomeService.AddInSupply(request);
            return new Response<GL_IncomeListModel>(glIncomeGen);
        }
    }
}
