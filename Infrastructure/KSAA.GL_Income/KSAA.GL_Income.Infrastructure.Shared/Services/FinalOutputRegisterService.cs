using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.Features.FinalOutputRegister.Commands;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class FinalOutputRegisterService : IFinalOutputRegisterService
    {
        private readonly IFinalOutputRegisterRepositoryAsync _finalOutputRegisterRepositoryAsync;
        public FinalOutputRegisterService(IFinalOutputRegisterRepositoryAsync finalOutputRegisterRepositoryAsync)
        {
            _finalOutputRegisterRepositoryAsync = finalOutputRegisterRepositoryAsync;
        }

        public async Task<FinalOutputRegisterListModel> GetFinalOutputRegister(string month, string year)
        {
            var finalOutputRegister = await _finalOutputRegisterRepositoryAsync.GetFinalOutputRegisterAsync(month, year);
            return finalOutputRegister;
        }

        public async Task<FinalOutputRegisterListModel> GenFinalOutputRegister(GenFinalOutputRegisterCommand command)
        {
            var genFinalOutput = await _finalOutputRegisterRepositoryAsync.GenFinalOutputRegister(command.Month, command.Year);
            return genFinalOutput;
        }

        public async Task<FinalOutputRegisterListModel> ExportFinalOutputRegister(string month, string year)
        {
            var finalOutputRegister = await _finalOutputRegisterRepositoryAsync.ExportFinalOutputRegisterAsync(month, year);
            return finalOutputRegister;
        }
    }
}
