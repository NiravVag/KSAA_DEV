using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Services
{
    public interface IClientAuthorizedSignatoryService
    {
        Task<ClientAuthorizedSignatoryViewModel> AddClientAuthorizedSignatory(CreateClientAuthorizedSignatoryCommand command);

        Task<ClientAuthorizedSignatoryViewModel> EditClientAuthorizedSignatory(UpdateClientAuthorizedSignatoryCommand command);

        Task<IEnumerable<ClientAuthorizedSignatoryListModel>> GetClientAuthorizedSignatoryList();

        Task<ClientAuthorizedSignatoryViewModel> GetClientAuthorizedSignatoryById(long id);

        Task DeleteClientAuthorizedSignatory(DeleteClientAuthorizedSignatoryCommand command);
    }
}
