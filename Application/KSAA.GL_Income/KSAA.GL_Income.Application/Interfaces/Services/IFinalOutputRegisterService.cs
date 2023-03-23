using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.GL_Income.Application.Features.FinalOutputRegister.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IFinalOutputRegisterService
    {
        Task<FinalOutputRegisterListModel> GetFinalOutputRegister(string month, string year);
        Task<FinalOutputRegisterListModel> ExportFinalOutputRegister(string month, string year);
        Task<FinalOutputRegisterListModel> GenFinalOutputRegister(GenFinalOutputRegisterCommand command);
    }
}
