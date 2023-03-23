using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
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
    public class ClientManagingDirectorService : IClientManagingDirectorService
    {
        private readonly IGenericRepositoryAsync<ClientManagingDirector> _ClientManagingDirectorRepositoryAsync;
        private readonly IMapper _mapper;

        public ClientManagingDirectorService(IGenericRepositoryAsync<ClientManagingDirector> ClientManagingDirectorRepositoryAsync, IMapper mapper)
        {
            _ClientManagingDirectorRepositoryAsync = ClientManagingDirectorRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<ClientManagingDirectorViewModel> AddClientManagingDirector(CreateClientManagingDirectorCommand command)
        {
            var applicationManagingDirector = _mapper.Map<ClientManagingDirector>(command);
            applicationManagingDirector.CreatedOn = DateTime.Now;
            applicationManagingDirector.IsActive = IsActive.Active;
            await _ClientManagingDirectorRepositoryAsync.AddAsync(applicationManagingDirector);

            return _mapper.Map<ClientManagingDirectorViewModel>(applicationManagingDirector);
        }

        public async Task DeleteClientManagingDirector(DeleteClientManagingDirectorCommand command)
        {
            if (command.Id > 0)
            {
                var applicationManagingDirector = await _ClientManagingDirectorRepositoryAsync.FindById(command.Id);
                applicationManagingDirector.IsActive = IsActive.Delete;
                await _ClientManagingDirectorRepositoryAsync.UpdateAsync(applicationManagingDirector);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<ClientManagingDirectorViewModel> EditClientManagingDirector(UpdateClientManagingDirectorCommand command)
        {
            var applicationManagingDirector = _mapper.Map<UpdateClientManagingDirectorCommand>(command);
            applicationManagingDirector.IsActive = IsActive.Active;
            applicationManagingDirector.ModifiedOn = DateTime.Now;
            var applicationUser = await _ClientManagingDirectorRepositoryAsync.FindById(applicationManagingDirector.Id);
            _mapper.Map(command, applicationUser);

            await _ClientManagingDirectorRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<ClientManagingDirectorViewModel>(applicationUser);
        }

        public async Task<ClientManagingDirectorViewModel> GetClientManagingDirectorById(long id)
        {
            var applicationManagingDirector = await _ClientManagingDirectorRepositoryAsync.FindById(id);
            return _mapper.Map<ClientManagingDirectorViewModel>(applicationManagingDirector);
        }

        public async Task<IEnumerable<ClientManagingDirectorListModel>> GetClientManagingDirectorList()
        {
            var ManagingDirectorList = await _ClientManagingDirectorRepositoryAsync.GetAllAsync();
            //ManagingDirectorList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<ClientManagingDirectorViewModel>>(ManagingDirectorList).Where(x => x.IsActive != IsActive.Delete);

            var ManagingDirectors = ManagingDirectorList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new ClientManagingDirectorListModel()
                {
                    Id = y.Id,
                    Name = y.Name,
                    FatherName = y.FatherName,
                    BOD = y.BOD.ToString(DateTimeFormat.StandardDateTime),
                    DesignationStatus = y.DesignationStatus,
                    MobileNumber = y.MobileNumber,
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
            return ManagingDirectors;
        }
    }
}
