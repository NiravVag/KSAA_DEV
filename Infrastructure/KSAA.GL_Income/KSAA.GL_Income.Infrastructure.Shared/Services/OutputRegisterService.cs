using KSAA.Domain.Entities.OutputRegister;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Interfaces.Repositories;
using KSAA.GL_Income.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Shared.Services
{
    public class OutputRegisterService : IOutputRegisterService
    {
        private readonly IOutputRegisterRepositoryAsync _outputRegisterRepositoryAsync;
        private readonly IGenericRepositoryAsync<OutputRegister> _genericRepositoryAsync;

        public OutputRegisterService(IOutputRegisterRepositoryAsync outputRegisterRepositoryAsync, IGenericRepositoryAsync<OutputRegister> genericRepositoryAsync)
        {
            _outputRegisterRepositoryAsync = outputRegisterRepositoryAsync;
            _genericRepositoryAsync = genericRepositoryAsync;

        }
        public Task<List<OutputRegisterViewModel>> GetOutputRegisterGrid(string month, string year)
        {
            var listAdvanceRecivedModule = _outputRegisterRepositoryAsync.GetOutputRegisterGridAsync(month, year);
            return listAdvanceRecivedModule;
        }
    }
}
