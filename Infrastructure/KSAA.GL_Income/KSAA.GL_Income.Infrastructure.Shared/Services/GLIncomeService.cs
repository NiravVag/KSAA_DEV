using AutoMapper;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.DocumentUpload;
using KSAA.Domain.Entities.GL_Income;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.Features.GLIncome.Commands.ControlSheetGLSL;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using KSAA.Master.Application.DTOs.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class GLIncomeService : IGLIncomeService
    {
        private readonly IGLIncomeRepositoryAsync _GL_IncomeRepositoryAsync;
        private readonly IGenericRepositoryAsync<SupplyRegister> _glIncomeRepositoryAsync;

        public GLIncomeService(IGLIncomeRepositoryAsync GL_IncomeRepositoryAsync, IGenericRepositoryAsync<SupplyRegister> glIncomeRepositoryAsync)
        {
            _GL_IncomeRepositoryAsync = GL_IncomeRepositoryAsync;
            _glIncomeRepositoryAsync = glIncomeRepositoryAsync;
        }

        public async Task<GL_IncomeListModel> GetGLIncomeControlSheet(string month, string year)
        {
            var GLControlSheet = await _GL_IncomeRepositoryAsync.GetGLIncomeControlSheetAsync(month, year);
            return GLControlSheet;
        }

        public async Task<GL_IncomeListModel> GenControlSheet(GenControlSheetCommand command)
        {
            var GenControlSheet = await _GL_IncomeRepositoryAsync.GenControlSheet(command.Month, command.Year);
            return GenControlSheet;
        }

        public async Task<GL_IncomeListModel> AddInSupply(AddToSupplyCommand command)
        {
            var GenControlSheet = await _GL_IncomeRepositoryAsync.AddInSupply(command);
            return GenControlSheet;
        }

        public async Task<CommonRequestViewModel> GetSLMonthYearList()
        {
            var monthyearList = await _glIncomeRepositoryAsync.GetAllAsync();
            var months = monthyearList.Select(x => x.Month).Distinct().ToList();
            var years = monthyearList.Select(x => x.Year).Distinct().ToList();

            return new CommonRequestViewModel()
            {
                Months = months,
                Years = years
            };
        }

        public async Task<List<SupplyModel>> GetPreViewDocumentList(string month, string year)
        {
            var GLControlSheet = await _GL_IncomeRepositoryAsync.GetPreViewDocumentList(month, year);
            return GLControlSheet;
        }

        public async Task<GSTRReplicaListModel> GetGSTRReplicaList(string month, string year)
        {
            var gSTRReplicaList = await _GL_IncomeRepositoryAsync.GetGSTRReplicaListAsync(month,year);
            return gSTRReplicaList;
        }
    }
}
