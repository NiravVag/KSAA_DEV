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
    public class GetGetSLInvoiceNoQuery : IRequest<Response<IEnumerable<OutputRegisterViewModel>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GetGetSLInvoiceNoQueryHandler : IRequestHandler<GetGetSLInvoiceNoQuery, Response<IEnumerable<OutputRegisterViewModel>>>
    {
        private readonly IAdvanceAdjustmentService _advaceAdjustmentService;

        public GetGetSLInvoiceNoQueryHandler(IAdvanceAdjustmentService advaceAdjustmentService)
        {
            _advaceAdjustmentService = advaceAdjustmentService;
        }
        public async Task<Response<IEnumerable<OutputRegisterViewModel>>> Handle(GetGetSLInvoiceNoQuery request, CancellationToken cancellationToken)
        {
            var InvoiceList = await _advaceAdjustmentService.GetSLInvoiceList(request.Month, request.Year);

            return new Response<IEnumerable<OutputRegisterViewModel>>(InvoiceList);
        }
    }
}
