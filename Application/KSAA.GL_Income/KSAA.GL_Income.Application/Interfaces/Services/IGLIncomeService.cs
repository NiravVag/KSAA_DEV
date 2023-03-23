using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
using KSAA.Master.Application.DTOs.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IGLIncomeService
    {
        Task<GL_IncomeListModel> GetGLIncomeControlSheet(string month, string year);
        Task<GL_IncomeListModel> GenControlSheet(GenControlSheetCommand command);
        Task<GL_IncomeListModel> AddInSupply(AddToSupplyCommand command);
        Task<CommonRequestViewModel> GetSLMonthYearList();
        Task<List<SupplyModel>> GetPreViewDocumentList(string month, string year);
        Task<GSTRReplicaListModel> GetGSTRReplicaList(string month, string year);
    }
}
