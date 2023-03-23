using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands
{
    public class AddTagInvoiceByIdCommand : IRequest<Response>
    {
        public long SLRegisterId { get; set; }
        public long AdvancedReceivedID { get; set; }
        public string? InvoiceAmount { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? AmendmentInvoiceAmount { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class AddTagInvoiceByIdCommandHandler : IRequestHandler<AddTagInvoiceByIdCommand, Response>
    {
        private readonly IAdvanceAdjustmentService _advaceAdjustmentService;

        public AddTagInvoiceByIdCommandHandler(IAdvanceAdjustmentService advaceAdjustmentService)
        {
            _advaceAdjustmentService = advaceAdjustmentService;
        }

        public async Task<Response> Handle(AddTagInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
           await _advaceAdjustmentService.AddTagInvoiceById(request);

            return new Response("Tag Invoice Add Successfully");
        }
    }
}
