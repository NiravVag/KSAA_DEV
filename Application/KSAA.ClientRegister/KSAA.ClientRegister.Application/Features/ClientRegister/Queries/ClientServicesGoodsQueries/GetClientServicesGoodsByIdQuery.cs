using AutoMapper;
using KSAA.ClientRegister.Application.DTOs.ClientRegister;
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
    public class GetClientServicesGoodsByIdQuery : IRequest<Response<ClientServicesGoodsViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetClientServicesGoodsByIdQueryHandler : IRequestHandler<GetClientServicesGoodsByIdQuery, Response<ClientServicesGoodsViewModel>>
    {
        private readonly IClientServicesGoodsService _ClientServicesGoodsService;
        private readonly IMapper _mapper;

        public GetClientServicesGoodsByIdQueryHandler(IClientServicesGoodsService ClientServicesGoodsService, IMapper mapper)
        {
            _ClientServicesGoodsService = ClientServicesGoodsService;
            _mapper = mapper;
        }
        public async Task<Response<ClientServicesGoodsViewModel>> Handle(GetClientServicesGoodsByIdQuery request, CancellationToken cancellationToken)
        {
            var getClientServicesGoodsById = await _ClientServicesGoodsService.GetClientServicesGoodsById(request.Id);
            return new Response<ClientServicesGoodsViewModel>(getClientServicesGoodsById);
        }
    }
}