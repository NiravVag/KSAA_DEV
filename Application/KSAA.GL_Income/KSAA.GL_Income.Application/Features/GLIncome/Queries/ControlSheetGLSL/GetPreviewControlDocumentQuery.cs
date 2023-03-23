using KSAA.Domain.Entities.GL_Income;
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
    public class GetPreviewControlDocumentQuery : IRequest<Response<IEnumerable<SupplyModel>>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class GetPreviewControlDocumentQueryHandler : IRequestHandler<GetPreviewControlDocumentQuery, Response<IEnumerable<SupplyModel>>>
    {
        private readonly IGLIncomeService _glIncomeService;

        public GetPreviewControlDocumentQueryHandler(IGLIncomeService glIncomeService)
        {
            _glIncomeService = glIncomeService;
        }
        public async Task<Response<IEnumerable<SupplyModel>>> Handle(GetPreviewControlDocumentQuery request, CancellationToken cancellationToken)
        {
            var documentTypeUploadList = await _glIncomeService.GetPreViewDocumentList(request.Month, request.Year);
            return new Response<IEnumerable<SupplyModel>>(documentTypeUploadList);
        }
    }
}
