using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.FunctionModuleCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface IFunctionModuleService
    {
        Task<FunctionModuleViewModel> AddFunctionModule(CreateFunctionModuleCommand command);

        Task<FunctionModuleViewModel> EditFunctionModule(UpdateFunctionModuleCommand command);

        Task<IEnumerable<FunctionModuleListModel>> GetFunctionModuleList();

        Task<FunctionModuleViewModel> GetFunctionModuleById(long id);

        Task DeleteFunctionModule(DeleteFunctionModuleCommand command);
    }
}
