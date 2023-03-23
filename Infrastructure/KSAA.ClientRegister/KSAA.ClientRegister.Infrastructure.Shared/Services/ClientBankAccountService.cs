using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Interfaces.Repositories;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.ClientRegister;
using KSAA.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Infrastructure.Shared.Services
{
    public class ClientBankAccountService : IClientBankAccountService
    {
        private readonly IGenericRepositoryAsync<ClientBankAccount> _ClientBankAccountRepositoryAsync;
        private readonly IMapper _mapper;

        public ClientBankAccountService(IGenericRepositoryAsync<ClientBankAccount> ClientBankAccountRepositoryAsync, IMapper mapper)
        {
            _ClientBankAccountRepositoryAsync = ClientBankAccountRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<ClientBankAccountViewModel> AddClientBankAccount(CreateClientBankAccountCommand command)
        {
            var applicationClientBankAccount = _mapper.Map<ClientBankAccount>(command);
            applicationClientBankAccount.CreatedOn = DateTime.Now;
            applicationClientBankAccount.IsActive = IsActive.Active;
            await _ClientBankAccountRepositoryAsync.AddAsync(applicationClientBankAccount);

            return _mapper.Map<ClientBankAccountViewModel>(applicationClientBankAccount);
        }

        public async Task DeleteClientBankAccount(DeleteClientBankAccountCommand command)
        {
            if (command.Id > 0)
            {
                var applicationClientBankAccount = await _ClientBankAccountRepositoryAsync.FindById(command.Id);
                applicationClientBankAccount.IsActive = IsActive.Delete;
                await _ClientBankAccountRepositoryAsync.UpdateAsync(applicationClientBankAccount);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<ClientBankAccountViewModel> EditClientBankAccount(UpdateClientBankAccountCommand command)
        {
            var applicationClientBankAccount = _mapper.Map<UpdateClientBankAccountCommand>(command);
            applicationClientBankAccount.IsActive = IsActive.Active;
            applicationClientBankAccount.ModifiedOn = DateTime.Now;
            var applicationUser = await _ClientBankAccountRepositoryAsync.FindById(applicationClientBankAccount.Id);
            _mapper.Map(command, applicationUser);

            await _ClientBankAccountRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<ClientBankAccountViewModel>(applicationUser);
        }

        public async Task<ClientBankAccountViewModel> GetClientBankAccountById(long id)
        {
            var applicationClientBankAccount = await _ClientBankAccountRepositoryAsync.FindById(id);
            return _mapper.Map<ClientBankAccountViewModel>(applicationClientBankAccount);
        }

        public async Task<IEnumerable<ClientBankAccountListModel>> GetClientBankAccountList()
        {
            var ClientBankAccountList = await _ClientBankAccountRepositoryAsync.GetAllAsync();
            //ClientBankAccountList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<ClientBankAccountViewModel>>(ClientBankAccountList).Where(x => x.IsActive != IsActive.Delete);

            var ClientBankAccounts = ClientBankAccountList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new ClientBankAccountListModel()
                {
                    Id = y.Id,
                    BranchName = y.BranchName,
                    AccountNo = y.AccountNo,
                    Type = y.Type,
                    IFSCCode = y.IFSCCode,
                    BankPassbookPage = y.BankPassbookPage,
                    StatementCancelledCheque = y.StatementCancelledCheque,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return ClientBankAccounts;
        }
    }
}