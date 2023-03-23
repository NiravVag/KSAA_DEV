using KSAA.GL_Income.Application.DTOs.OutputRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IOutputRegisterService
    {
        Task<List<OutputRegisterViewModel>> GetOutputRegisterGrid(string month, string year);
    }
}
