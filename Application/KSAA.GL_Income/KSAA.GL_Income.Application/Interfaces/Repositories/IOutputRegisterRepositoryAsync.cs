using KSAA.GL_Income.Application.DTOs.OutputRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IOutputRegisterRepositoryAsync
    {
        Task<List<OutputRegisterViewModel>> GetOutputRegisterGridAsync(string month, string year);
    }
}
