using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientServicesGoodsQueries;
using KSAA.ClientRegister.Application.Interfaces.Services;
using KSAA.ClientRegister.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Features.ClientRegister.Queries.ClientServicesGoodsQueries
{
    public class GetAllClientServicesGoodsQuery : IRequest<Response<IEnumerable<ClientServicesGoodsListModel>>>
    {
    }

    public class GetAllClientServicesGoodsQueryHandler : IRequestHandler<GetAllClientServicesGoodsQuery, Response<IEnumerable<ClientServicesGoodsListModel>>>
    {
        private readonly IClientServicesGoodsService _ClientServicesGoodsService;
        private readonly IMapper _mapper;

        public GetAllClientServicesGoodsQueryHandler(IClientServicesGoodsService ClientServicesGoodsService, IMapper mapper)
        {
            _ClientServicesGoodsService = ClientServicesGoodsService;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientServicesGoodsListModel>>> Handle(GetAllClientServicesGoodsQuery request, CancellationToken cancellationToken)
        {
            var ClientServicesGoodsList = await _ClientServicesGoodsService.GetClientServicesGoodsList();

            return new Response<IEnumerable<ClientServicesGoodsListModel>>(ClientServicesGoodsList);
        }
    }
}
