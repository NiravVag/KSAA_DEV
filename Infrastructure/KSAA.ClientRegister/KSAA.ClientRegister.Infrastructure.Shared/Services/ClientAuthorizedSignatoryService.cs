using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.ClientRegister;
using KSAA.Domain.Entities.Master;
using KSAA.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Infrastructure.Shared.Services
{
    public class ClientAuthorizedSignatoryService : IClientAuthorizedSignatoryService
    {
        private readonly IGenericRepositoryAsync<ClientAuthorizedSignatory> _ClientAuthorizedSignatoryRepositoryAsync;
        private readonly IMapper _mapper;

        public ClientAuthorizedSignatoryService(IGenericRepositoryAsync<ClientAuthorizedSignatory> ClientAuthorizedSignatoryRepositoryAsync, IMapper mapper)
        {
            _ClientAuthorizedSignatoryRepositoryAsync = ClientAuthorizedSignatoryRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<ClientAuthorizedSignatoryViewModel> AddClientAuthorizedSignatory(CreateClientAuthorizedSignatoryCommand command)
        {
            var applicationClientAuthorizedSignatory = _mapper.Map<ClientAuthorizedSignatory>(command);
            applicationClientAuthorizedSignatory.CreatedOn = DateTime.Now;
            applicationClientAuthorizedSignatory.IsActive = IsActive.Active;
            await _ClientAuthorizedSignatoryRepositoryAsync.AddAsync(applicationClientAuthorizedSignatory);

            return _mapper.Map<ClientAuthorizedSignatoryViewModel>(applicationClientAuthorizedSignatory);
        }

        public async Task DeleteClientAuthorizedSignatory(DeleteClientAuthorizedSignatoryCommand command)
        {
            if (command.Id > 0)
            {
                var applicationClientAuthorizedSignatory = await _ClientAuthorizedSignatoryRepositoryAsync.FindById(command.Id);
                applicationClientAuthorizedSignatory.IsActive = IsActive.Delete;
                await _ClientAuthorizedSignatoryRepositoryAsync.UpdateAsync(applicationClientAuthorizedSignatory);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<ClientAuthorizedSignatoryViewModel> EditClientAuthorizedSignatory(UpdateClientAuthorizedSignatoryCommand command)
        {
            var applicationClientAuthorizedSignatory = _mapper.Map<UpdateClientAuthorizedSignatoryCommand>(command);
            applicationClientAuthorizedSignatory.IsActive = IsActive.Active;
            applicationClientAuthorizedSignatory.ModifiedOn = DateTime.Now;
            var applicationUser = await _ClientAuthorizedSignatoryRepositoryAsync.FindById(applicationClientAuthorizedSignatory.Id);
            _mapper.Map(command, applicationUser);

            await _ClientAuthorizedSignatoryRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<ClientAuthorizedSignatoryViewModel>(applicationUser);
        }

        public async Task<ClientAuthorizedSignatoryViewModel> GetClientAuthorizedSignatoryById(long id)
        {
            var applicationClientAuthorizedSignatory = await _ClientAuthorizedSignatoryRepositoryAsync.FindById(id);
            return _mapper.Map<ClientAuthorizedSignatoryViewModel>(applicationClientAuthorizedSignatory);
        }

        public async Task<IEnumerable<ClientAuthorizedSignatoryListModel>> GetClientAuthorizedSignatoryList()
        {
            var ClientAuthorizedSignatoryList = await _ClientAuthorizedSignatoryRepositoryAsync.GetAllAsync();
            //ClientAuthorizedSignatoryList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<ClientAuthorizedSignatoryViewModel>>(ClientAuthorizedSignatoryList).Where(x => x.IsActive != IsActive.Delete);

            var ClientAuthorizedSignatorys = ClientAuthorizedSignatoryList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new ClientAuthorizedSignatoryListModel()
                {
                    Id = y.Id,
                    FirstName = y.FirstName,
                    MiddleName = y.MiddleName,
                    LastName = y.LastName,
                    FatherFirstName = y.FatherFirstName,
                    FatherMiddleName = y.FatherMiddleName,
                    FatherLastName = y.FatherLastName,
                    BOD = y.BOD.ToString(DateTimeFormat.StandardDateTime),
                    Gender = y.Gender,
                    DesignationStatus = y.DesignationStatus,
                    Mobile = y.Mobile,
                    PhoneNoSTD = y.PhoneNoSTD,
                    Email = y.Email,
                    Address = y.Address,
                    PAN = y.PAN,
                    DIN = y.DIN,
                    Indian = y.Indian,
                    Photo = y.Photo,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return ClientAuthorizedSignatorys;
        }
    }
}
