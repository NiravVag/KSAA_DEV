using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
using KSAA.GL_Income.Application.Features.OutputLiability.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IOutputLiabilityService
    {
        Task<OutputLiabilityListModel> GetOutputLiabilityControlSheet(string month, string year);
        Task<OutputLiabilityListModel> GenLiabilityControlSheet(GenLiabilityControlSheetCommand command);
        Task<OutputLiabilityListModel> AddInSupply(AddToSupplyOutputLiabliyCommand command);
        Task<List<OutputSupplyViewModel>> GetPreViewDocumentList(string month, string year);
        Task<HttpResponseMessage> LiabilityControlDataById(UpdateLiabilityControlDataByIdCommand command);

    }
}
