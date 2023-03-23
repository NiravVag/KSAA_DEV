using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.AdvanceMappingCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
	public interface IAdvanceMappingService
	{
        Task<AdvanceMappingViewModel> AddAdvanceMapping(CreateAdvanceMappingCommand command);
        Task DeleteAdvanceMapping(DeleteAdvanceMappingCommand command);
        Task<AdvanceMappingViewModel> EditAdvanceMapping(UpdateAdvanceMappingCommand command);
        Task<AdvanceMappingViewModel> GetAdvanceMappingById(long id);
        Task<IEnumerable<AdvanceMappingListModel>> GetAdvanceMappingList();
    }
}
