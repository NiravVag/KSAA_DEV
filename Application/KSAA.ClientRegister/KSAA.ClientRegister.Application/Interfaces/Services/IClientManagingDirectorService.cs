using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Services
{
    public interface IClientManagingDirectorService
    {
        Task<ClientManagingDirectorViewModel> AddClientManagingDirector(CreateClientManagingDirectorCommand command);

        Task<ClientManagingDirectorViewModel> EditClientManagingDirector(UpdateClientManagingDirectorCommand command);

        Task<IEnumerable<ClientManagingDirectorListModel>> GetClientManagingDirectorList();

        Task<ClientManagingDirectorViewModel> GetClientManagingDirectorById(long id);

        Task DeleteClientManagingDirector(DeleteClientManagingDirectorCommand command);
    }
}
