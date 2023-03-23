using KSAA.GL_Income.Application.DTOs.OutputRegister;
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
    public class GetSLInvoiceDetailByIdQuery : IRequest<Response<OutputRegisterViewModel>>
    {
        public long Id { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class GetSLInvoiceDetailByIdQueryHandler : IRequestHandler<GetSLInvoiceDetailByIdQuery, Response<OutputRegisterViewModel>>
    {
        private readonly IAdvanceAdjustmentService _advaceAdjustmentService;

        public GetSLInvoiceDetailByIdQueryHandler(IAdvanceAdjustmentService advaceAdjustmentService)
        {
            _advaceAdjustmentService = advaceAdjustmentService;
        }

        public async Task<Response<OutputRegisterViewModel>> Handle(GetSLInvoiceDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var advanceAmendment = await _advaceAdjustmentService.GetSLInvoiceDetailById(request.Id, request.Month, request.Year);
            return new Response<OutputRegisterViewModel>(advanceAmendment);
        }
    }
}
