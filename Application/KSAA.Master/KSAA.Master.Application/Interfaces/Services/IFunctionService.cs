using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.FunctionCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface IFunctionService
    {
        Task<FunctionViewModel> AddFunction(CreateFunctionCommand command);

        Task<FunctionViewModel> EditFunction(UpdateFunctionCommand command);

        Task<IEnumerable<FunctionListModel>> GetFunctionList();

        Task<FunctionViewModel> GetFunctionById(long id);

        Task DeleteFunction(DeleteFunctionCommand command);
    }
}
