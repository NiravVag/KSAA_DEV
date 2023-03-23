using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.Features.AdvanceRecAdj.Commands;
using KSAA.Master.Application.DTOs.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Services
{
    public interface IAdvaceReceivedService
    {
        Task<AdvanceReceivedListModule> GetAdvaceReceivedModuleList(string month, string year);
        Task<CommonRequestViewModel> GetAdvReceivedMonthYearList();
        Task<HttpResponseMessage> AddReceivedAmendment(GetReceivedAmendmentByIdCommand command);
        Task<AdvanceAmendmentViewModel> AddReceivedAmendmentById(AddReceivedAmendmentByIdCommand command);
        Task<List<AdvanceAmendmentViewModel>> GetPreviewAddAmendmentByIdList(long id, string month, string year);
    }
}
