using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Services
{
    public interface IClientServicesGoodsService
    {
        Task<ClientServicesGoodsViewModel> AddClientServicesGoods(CreateClientServicesGoodsCommand command);

        Task<ClientServicesGoodsViewModel> EditClientServicesGoods(UpdateClientServicesGoodsCommand command);

        Task<IEnumerable<ClientServicesGoodsListModel>> GetClientServicesGoodsList();

        Task<ClientServicesGoodsViewModel> GetClientServicesGoodsById(long id);

        Task DeleteClientServicesGoods(DeleteClientServicesGoodsCommand command);
    }
}
