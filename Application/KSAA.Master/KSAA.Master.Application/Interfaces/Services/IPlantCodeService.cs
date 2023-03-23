using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Features.Master.Commands.PlantCodeCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Interfaces.Services
{
    public interface IPlantCodeService
    {
        Task<PlantCodeViewModel> AddPlantCode(CreatePlantCodeCommand command);

        Task<PlantCodeViewModel> EditPlantCode(UpdatePlantCodeCommand command);

        Task<IEnumerable<PlantCodeListModel>> GetPlantCodeList();

        Task<PlantCodeViewModel> GetPlantCodeById(long id);

        Task DeletePlantCode(DeletePlantCodeCommand command);
    }
}
