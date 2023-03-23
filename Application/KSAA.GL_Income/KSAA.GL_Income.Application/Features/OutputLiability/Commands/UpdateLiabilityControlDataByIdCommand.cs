using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.OutputLiability.Commands
{
    public class UpdateLiabilityControlDataByIdCommand : IRequest<Response<HttpResponseMessage>>
    {
        public long Id { get; set; }
        //public string? Invoice_Number { get; set; }
        public decimal Central_Tax { get; set; }
        public decimal State_UT_Tax { get; set; }
        public decimal Integrated_Tax { get; set; }
        public decimal Cess_Amount { get; set; }

        //public string? Invoice_Number_LL { get; set; }
        public decimal CGSTLL { get; set; }
        public decimal SGSTLL { get; set; }
        public decimal IGSTLL { get; set; }
        public decimal CessLL { get; set; }

        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class UpdateLiabilityControlDataByIdCommandHandler : IRequestHandler<UpdateLiabilityControlDataByIdCommand, Response<HttpResponseMessage>>
    {
        private readonly IOutputLiabilityService _outputLiabilityService;

        public UpdateLiabilityControlDataByIdCommandHandler(IOutputLiabilityService outputLiabilityService)
        {
            _outputLiabilityService = outputLiabilityService;
        }
        public async Task<Response<HttpResponseMessage>> Handle(UpdateLiabilityControlDataByIdCommand request, CancellationToken cancellationToken)
        {
            var updateLCData = await _outputLiabilityService.LiabilityControlDataById(request);
            return new Response<HttpResponseMessage>(updateLCData);
        }
    }
}
