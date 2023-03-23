using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using KSAA.Master.Application.DTOs.DocumentUpload;
using KSAA.Master.Application.DTOs.IAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Repositories
{
    public interface IDocumentTypeRepositoryAsync
    {
        Task<GLIncomeRegisterListModel> GetGLDocumentPrivew(string month, string year);
        Task<SupplyRegisterListModel> GetSLDocumentPrivew(string month, string year);
        Task<EInvoiceRegisterListModel> GetEInvoiceDocumentPrivew(string month, string year);
        Task<EWayBillRegisterListModel> GetEWayBillDocumentPrivew(string month, string year);
        Task<LiabilityLedgerListModel> GetLLDocumentPrivew(string month, string year);
        Task<FinalOutputRegisterListModel> GetFOPDocumentPreview(string month, string year);

        Task<AdvanceReceivedListModel> GetAdvRecDocumentPrivew(string month, string year);
        Task<bool> UpdateInvoiceAmendmentData(List<InvoiceAmendmentUpdateViewModel> invoiceAmendmentUpdateList);
    }
}