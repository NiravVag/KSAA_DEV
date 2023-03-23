using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Services
{
    public interface IClientBankAccountService
    {
        Task<ClientBankAccountViewModel> AddClientBankAccount(CreateClientBankAccountCommand command);

        Task<ClientBankAccountViewModel> EditClientBankAccount(UpdateClientBankAccountCommand command);

        Task<IEnumerable<ClientBankAccountListModel>> GetClientBankAccountList();

        Task<ClientBankAccountViewModel> GetClientBankAccountById(long id);

        Task DeleteClientBankAccount(DeleteClientBankAccountCommand command);
    }
}
