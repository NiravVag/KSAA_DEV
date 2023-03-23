using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.GSTOutputLiabilityCodesCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
	public interface IGSTOutputLiabilityCodesService
	{
        Task<GSTOutputLiabilityCodesViewModel> AddGSTOutputLiabilityCodes(CreateGSTOutputLiabilityCodesCommand command);
        Task DeleteGSTOutputLiabilityCodes(DeleteGSTOutputLiabilityCodesCommand command);
        Task<GSTOutputLiabilityCodesViewModel> EditGSTOutputLiabilityCodes(UpdateGSTOutputLiabilityCodesCommand command);
        Task<GSTOutputLiabilityCodesViewModel> GetGSTOutputLiabilityCodesById(long id);
        Task<IEnumerable<GSTOutputLiabilityCodesListModel>> GetGSTOutputLiabilityCodesList();
    }
}
