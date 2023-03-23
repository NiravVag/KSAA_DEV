using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.TBTaggingCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface ITBTaggingService
    {
        Task<TBTaggingViewModel> AddTBTagging(CreateTBTaggingCommand command);

        Task<TBTaggingViewModel> EditTBTagging(UpdateTBTaggingCommand command);

        Task<IEnumerable<TBTaggingListModel>> GetTBTaggingList();

        Task<TBTaggingViewModel> GetTBTaggingById(long id);

        Task DeleteTBTagging(DeleteTBTaggingCommand command);
    }
}
