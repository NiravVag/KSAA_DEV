using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.GLIncome_MappingCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface IGLIncome_MappingService
    {
        Task<GLIncome_MappingViewModel> AddGLIncome_Mapping(CreateGLIncome_MappingCommand command);

        Task<GLIncome_MappingViewModel> EditGLIncome_Mapping(UpdateGLIncome_MappingCommand command);

        Task<IEnumerable<GLIncome_MappingListModel>> GetGLIncome_MappingList();

        Task<GLIncome_MappingViewModel> GetGLIncome_MappingById(long id);

        Task DeleteGLIncome_Mapping(DeleteGLIncome_MappingCommand command);
    }
}
