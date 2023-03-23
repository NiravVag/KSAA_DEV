using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IAdvanceAdjustmentService
    {
        Task<List<AdvanceAdjustmentViewModel>> GetAdvanceAdjustmentList(string month, string year);
        Task<AdvanceAdjustmentViewModel> GetAdvanceAdjustmentById(long id, string month, string year);

        Task<IEnumerable<OutputRegisterViewModel>> GetSLInvoiceList(string month, string year);
        Task<AdvanceAdjustmentTagReceiptModel> AddTagInvoiceById(AddTagInvoiceByIdCommand command);
        Task<OutputRegisterViewModel> GetSLInvoiceDetailById(long id, string month, string year);
    }
}
