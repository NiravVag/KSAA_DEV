using KSAA.DocumentService.Classes;
using KSAA.Master.Application.DTOs.Master;

namespace KSAA.DocumentService.Interfaces
{
    public interface IBase
    {
        //Task<bool> Import(DocumentTypeUpload docInformation);
        Task<ColumnsDataOperation> Import(DocumentTypeUpload docInformation);
        Task<ColumnsDataOperation> PreViewDocument(DocumentTypeUpload docPreView);
    }
}
