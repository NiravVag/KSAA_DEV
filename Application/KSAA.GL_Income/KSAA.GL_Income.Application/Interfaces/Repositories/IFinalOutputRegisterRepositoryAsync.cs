using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IFinalOutputRegisterRepositoryAsync
    {
        Task<FinalOutputRegisterListModel> GetFinalOutputRegisterAsync(string month, string year);
        Task<FinalOutputRegisterListModel> ExportFinalOutputRegisterAsync(string month, string year);
        Task<FinalOutputRegisterListModel> GenFinalOutputRegister(string month, string year);
    }
}
