using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Features.OutputLiability.Commands;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class OutputLiabilityService : IOutputLiabilityService
    {
        private readonly IOutputLiabilityRepositoryAsync _outputLiabilityRepositoryAsync;

        public OutputLiabilityService(IOutputLiabilityRepositoryAsync outputLiabilityRepositoryAsync)
        {
            _outputLiabilityRepositoryAsync = outputLiabilityRepositoryAsync;
        }
        public async Task<OutputLiabilityListModel> GenLiabilityControlSheet(GenLiabilityControlSheetCommand command)
        {
            var GenLiabilityControlSheet = await _outputLiabilityRepositoryAsync.GenLiabilityControlSheetAsync(command.Month, command.Year);
            return GenLiabilityControlSheet;
        }

        public async Task<OutputLiabilityListModel> GetOutputLiabilityControlSheet(string month, string year)
        {
            var utputLiabilityControlSheet = await _outputLiabilityRepositoryAsync.GetGLIncomeControlSheetAsync(month, year);
            return utputLiabilityControlSheet;
        }

        public async Task<OutputLiabilityListModel> AddInSupply(AddToSupplyOutputLiabliyCommand command)
        {
            var GenControlSheet = await _outputLiabilityRepositoryAsync.AddInSupply(command);
            return GenControlSheet;
        }

        public async Task<List<OutputSupplyViewModel>> GetPreViewDocumentList(string month, string year)
        {
            var outputLiability = await _outputLiabilityRepositoryAsync.GetPreViewDocumentList(month, year);
            return outputLiability;
        }

        public async Task<HttpResponseMessage> LiabilityControlDataById(UpdateLiabilityControlDataByIdCommand command)
        {
            var updateComparisonSheet = await _outputLiabilityRepositoryAsync.LiabilityControlDataById(command);
            return updateComparisonSheet;
        }
    }
}
