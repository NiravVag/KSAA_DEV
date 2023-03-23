using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IAdvanceAdjustmentRepositoryAsync
    {
        Task<List<AdvanceAdjustmentViewModel>> GetAdvanceAdjustmentAsync(string month, string year);
        Task<AdvanceAdjustmentViewModel> GetAdjustmentAmendmentById(long id, string month, string year);
        Task<List<OutputRegisterViewModel>> GetSLInvoiceList(string month, string year);
        Task<AdvanceAdjustmentTagReceiptModel> AddTagInvoiceById(AddTagInvoiceByIdCommand command);
        Task<OutputRegisterViewModel> GetSLInvoiceDetailById(long id, string month, string year);
    }
}
