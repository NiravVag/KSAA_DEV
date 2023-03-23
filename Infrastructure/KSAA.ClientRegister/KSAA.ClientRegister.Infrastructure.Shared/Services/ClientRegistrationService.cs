using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using KSAA.ClientRegister.Application.Interfaces.Repositories;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.Domain.Common;
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
    public class ClientRegistrationService : IClientRegistrationService
    {
        private readonly IGenericRepositoryAsync<ClientRegistration> _ClientRegistrationRepositoryAsync;
        private readonly IMapper _mapper;

        public ClientRegistrationService(IGenericRepositoryAsync<ClientRegistration> ClientRegistrationRepositoryAsync, IMapper mapper)
        {
            _ClientRegistrationRepositoryAsync = ClientRegistrationRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<ClientRegistrationViewModel> AddClientRegistration(CreateClientRegistrationCommand command)
        {
            var applicationRegistration = _mapper.Map<ClientRegistration>(command);
            applicationRegistration.CreatedOn = DateTime.Now;
            applicationRegistration.IsActive = IsActive.Active;
            await _ClientRegistrationRepositoryAsync.AddAsync(applicationRegistration);

            return _mapper.Map<ClientRegistrationViewModel>(applicationRegistration);
        }

        public async Task DeleteClientRegistration(DeleteClientRegistrationCommand command)
        {
            if (command.Id > 0)
            {
                var applicationRegistration = await _ClientRegistrationRepositoryAsync.FindById(command.Id);
                applicationRegistration.IsActive = IsActive.Delete;
                await _ClientRegistrationRepositoryAsync.UpdateAsync(applicationRegistration);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<ClientRegistrationViewModel> EditClientRegistration(UpdateClientRegistrationCommand command)
        {
            var applicationRegistration = _mapper.Map<UpdateClientRegistrationCommand>(command);
            applicationRegistration.IsActive = IsActive.Active;
            applicationRegistration.ModifiedOn = DateTime.Now;
            var applicationUser = await _ClientRegistrationRepositoryAsync.FindById(applicationRegistration.Id);
            _mapper.Map(command, applicationUser);

            await _ClientRegistrationRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<ClientRegistrationViewModel>(applicationUser);
        }

        public async Task<ClientRegistrationViewModel> GetClientRegistrationById(long id)
        {
            var applicationRegistration = await _ClientRegistrationRepositoryAsync.FindById(id);
            return _mapper.Map<ClientRegistrationViewModel>(applicationRegistration);
        }

        public async Task<IEnumerable<ClientRegistrationListModel>> GetClientRegistrationList()
        {
            var RegistrationList = await _ClientRegistrationRepositoryAsync.GetAllAsync();
            //RegistrationList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<ClientRegistrationViewModel>>(RegistrationList).Where(x => x.IsActive != IsActive.Delete);

            var Registrations = RegistrationList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new ClientRegistrationListModel()
                {
                    Id = y.Id,
                    RegistrationType = y.RegistrationType,
                    RegistrationNumber = y.RegistrationNumber,
                    RegistrationDate = y.RegistrationDate.ToString(DateTimeFormat.StandardDateTime),
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return Registrations;
        }
    }
}
