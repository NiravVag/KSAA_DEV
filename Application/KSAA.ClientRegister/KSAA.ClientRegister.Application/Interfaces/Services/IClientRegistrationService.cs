using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Services
{
    public interface IClientRegistrationService
    {
        Task<ClientRegistrationViewModel> AddClientRegistration(CreateClientRegistrationCommand command);

        Task<ClientRegistrationViewModel> EditClientRegistration(UpdateClientRegistrationCommand command);

        Task<IEnumerable<ClientRegistrationListModel>> GetClientRegistrationList();

        Task<ClientRegistrationViewModel> GetClientRegistrationById(long id);

        Task DeleteClientRegistration(DeleteClientRegistrationCommand command);
    }
}
