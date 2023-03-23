using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Features.OutputLiability.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IOutputLiabilityRepositoryAsync
    {
        Task<OutputLiabilityListModel> GetGLIncomeControlSheetAsync(string month, string year);
        Task<OutputLiabilityListModel> GenLiabilityControlSheetAsync(string month, string year);
        Task<OutputLiabilityListModel> AddInSupply(AddToSupplyOutputLiabliyCommand command);
        Task<List<OutputSupplyViewModel>> GetPreViewDocumentList(string month, string year);
        Task<HttpResponseMessage> LiabilityControlDataById(UpdateLiabilityControlDataByIdCommand command);
    }
}
