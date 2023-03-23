using KSAA.Master.Application.DTOs.IAD;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.DocumentTypeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface IDocumentTypeService
    {
        Task<DocumentTypeViewModel> AddDocumentType(CreateDocumentTypeCommand command);

        Task<DocumentTypeViewModel> EditDocumentType(UpdateDocumentTypeCommand command);

        Task<IEnumerable<DocumentTypeListModel>> GetDocumentTypeList();

        Task<DocumentTypeViewModel> GetDocumentTypeById(long id);

        Task DeleteDocumentType(DeleteDocumentTypeCommand command);

        Task<object> GetPreViewDocumentList(string month, string year, string type);
        Task<long> GetDocumentData(string month, string year, string type);
        Task DeleteData(DeleteDataCommand command);
        Task<bool> UpdateInvoiceAmendmentData(List<InvoiceAmendmentUpdateViewModel> invoiceAmendmentUpdateList);
    }
}
