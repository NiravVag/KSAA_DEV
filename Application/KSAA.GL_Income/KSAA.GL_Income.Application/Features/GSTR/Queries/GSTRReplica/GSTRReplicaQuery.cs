using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Queries.ComparisonReport;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.GL_Income.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Features.GSTR.Queries.GSTRReplica
{
    public class GSTRReplicaQuery : IRequest<Response<GSTRReplicaListModel>>
    {
        public string? Month { get; set; }
        public string? Year { get; set; }
    }

    public class GSTRReplicaQueryHandler : IRequestHandler<GSTRReplicaQuery, Response<GSTRReplicaListModel>>
    {
        private readonly IGLIncomeService _gLIncomeService;

        public GSTRReplicaQueryHandler(IGLIncomeService gLIncomeService)
        {
            _gLIncomeService = gLIncomeService;
        }

        public async Task<Response<GSTRReplicaListModel>> Handle(GSTRReplicaQuery request, CancellationToken cancellationToken)
        {
            var glIncomeList = await _gLIncomeService.GetGSTRReplicaList(request.Month, request.Year);
            return new Response<GSTRReplicaListModel>(glIncomeList);
        }
    }
}
