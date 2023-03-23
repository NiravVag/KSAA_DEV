using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientAuthorizedSignatoryCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientBankAccountCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientManagingDirectorCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientRegistrationCommand;
using KSAA.ClientRegister.Application.Features.ClientRegister.Commands.ClientServicesGoodsCommand;
using KSAA.Domain.Entities.ClientRegister;
using KSAA.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateClientAuthorizedSignatoryCommand, ClientAuthorizedSignatory>();
            CreateMap<UpdateClientAuthorizedSignatoryCommand, ClientAuthorizedSignatory>();
            CreateMap<ClientAuthorizedSignatory, ClientAuthorizedSignatoryViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateClientBankAccountCommand, ClientBankAccount>();
            CreateMap<UpdateClientBankAccountCommand, ClientBankAccount>();
            CreateMap<ClientBankAccount, ClientBankAccountViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateClientManagingDirectorCommand, ClientManagingDirector>();
            CreateMap<UpdateClientManagingDirectorCommand, ClientManagingDirector>();
            CreateMap<ClientManagingDirector, ClientManagingDirectorViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateClientRegistrationCommand, ClientRegistration>();
            CreateMap<UpdateClientRegistrationCommand, ClientRegistration>();
            CreateMap<ClientRegistration, ClientRegistrationViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<CreateClientServicesGoodsCommand, ClientServicesGoods>();
            CreateMap<UpdateClientServicesGoodsCommand, ClientServicesGoods>();
            CreateMap<ClientServicesGoods, ClientServicesGoodsViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}
