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
    public class AddReceivedAmendmentByIdCommand : IRequest<Response>
    {        
        public long AdvanceReceivedId { get; set; }
        //public string? InvoiceNumber { get; set; }
        public string? ReceiptNumber { get; set; }
        //public string? GSTIN { get; set; }
        public decimal? TaxableValue { get; set; }
        public decimal? Rate { get; set; }
        public decimal? CessPercentage { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? Cess { get; set; }
        public decimal? TotalTax { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class AddReceivedAmendmentByIdCommandHandler : IRequestHandler<AddReceivedAmendmentByIdCommand, Response>
    {
        private readonly IAdvaceReceivedService _advaceReceivedService;

        public AddReceivedAmendmentByIdCommandHandler(IAdvaceReceivedService advaceReceivedService)
        {
            _advaceReceivedService = advaceReceivedService;
        }

        public async Task<Response> Handle(AddReceivedAmendmentByIdCommand request, CancellationToken cancellationToken)
        {
            var advanceAmendment = await _advaceReceivedService.AddReceivedAmendmentById(request);

            return new Response("Amendment Add Successfully");
        }
    }
}
