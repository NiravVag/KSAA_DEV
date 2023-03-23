using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.Interfaces.Repositories
{
    public interface IAdvaceReceivedRepositoryAsync
    {
        Task<AdvanceReceivedListModule> GetAdvaceReceivedModuleList(string month, string year);
        Task<HttpResponseMessage> AddReceivedAmendment(long id, string month, string year);
        Task<List<AdvanceAmendmentViewModel>> GetPreviewAddAmendmentByIdList(long id, string month, string year);
        Task<AdvanceReceivedViewModule> UpdateAdvanceReceivedById(long id, string month, string year);
    }
}
