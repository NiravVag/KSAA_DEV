using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IGLIncomeRepositoryAsync
    {
        Task<GL_IncomeListModel> GetGLIncomeControlSheetAsync(string month, string year);
        Task<GL_IncomeListModel> GenControlSheet(string month, string year);
        Task<GL_IncomeListModel> AddInSupply(AddToSupplyCommand command);
        Task<List<SupplyModel>> GetPreViewDocumentList(string month, string year);
        Task<GSTRReplicaListModel> GetGSTRReplicaListAsync(string month, string year);
    }
}
