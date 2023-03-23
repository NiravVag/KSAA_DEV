using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
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
    public class ClientServicesGoodsService : IClientServicesGoodsService
    {
        private readonly IGenericRepositoryAsync<ClientServicesGoods> _ClientServicesGoodsRepositoryAsync;
        private readonly IMapper _mapper;

        public ClientServicesGoodsService(IGenericRepositoryAsync<ClientServicesGoods> ClientServicesGoodsRepositoryAsync, IMapper mapper)
        {
            _ClientServicesGoodsRepositoryAsync = ClientServicesGoodsRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<ClientServicesGoodsViewModel> AddClientServicesGoods(CreateClientServicesGoodsCommand command)
        {
            var applicationServicesGoods = _mapper.Map<ClientServicesGoods>(command);
            applicationServicesGoods.CreatedOn = DateTime.Now;
            applicationServicesGoods.IsActive = IsActive.Active;
            await _ClientServicesGoodsRepositoryAsync.AddAsync(applicationServicesGoods);

            return _mapper.Map<ClientServicesGoodsViewModel>(applicationServicesGoods);
        }

        public async Task DeleteClientServicesGoods(DeleteClientServicesGoodsCommand command)
        {
            if (command.Id > 0)
            {
                var applicationServicesGoods = await _ClientServicesGoodsRepositoryAsync.FindById(command.Id);
                applicationServicesGoods.IsActive = IsActive.Delete;
                await _ClientServicesGoodsRepositoryAsync.UpdateAsync(applicationServicesGoods);
            }
            else
            {
                throw new Application.Exceptions.BadRequestException("Invalid request");
            }
        }

        public async Task<ClientServicesGoodsViewModel> EditClientServicesGoods(UpdateClientServicesGoodsCommand command)
        {
            var applicationServicesGoods = _mapper.Map<UpdateClientServicesGoodsCommand>(command);
            applicationServicesGoods.IsActive = IsActive.Active;
            applicationServicesGoods.ModifiedOn = DateTime.Now;
            var applicationUser = await _ClientServicesGoodsRepositoryAsync.FindById(applicationServicesGoods.Id);
            _mapper.Map(command, applicationUser);

            await _ClientServicesGoodsRepositoryAsync.UpdateAsync(applicationUser);

            return _mapper.Map<ClientServicesGoodsViewModel>(applicationUser);
        }

        public async Task<ClientServicesGoodsViewModel> GetClientServicesGoodsById(long id)
        {
            var applicationServicesGoods = await _ClientServicesGoodsRepositoryAsync.FindById(id);
            return _mapper.Map<ClientServicesGoodsViewModel>(applicationServicesGoods);
        }

        public async Task<IEnumerable<ClientServicesGoodsListModel>> GetClientServicesGoodsList()
        {
            var ServicesGoodsList = await _ClientServicesGoodsRepositoryAsync.GetAllAsync();
            //ServicesGoodsList.OrderByDescending(x => x.Id).ToList();
            //return _mapper.Map<List<ClientServicesGoodsViewModel>>(ServicesGoodsList).Where(x => x.IsActive != IsActive.Delete);

            var ServicesGoodss = ServicesGoodsList.Where(x => x.IsActive != IsActive.Delete)
                .Select(y => new ClientServicesGoodsListModel()
                {
                    Id = y.Id,
                    ServicesName = y.ServicesName,
                    ServicesCode = y.ServicesCode,
                    IP = y.IP,
                    BrowserCase = y.BrowserCase,
                    IsActive = y.IsActive
                }).OrderByDescending(x => x.Id).ToList();
            return ServicesGoodss;
        }
    }
}
