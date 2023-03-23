using AutoMapper;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.Interfaces.Services;
using KSAA.Master.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.Features.Master.Queries.CustomerCodeQueries
{
    public class GetCustomerCodeByIdQuery : IRequest<Response<CustomerCodeViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerCodeByIdQuery, Response<CustomerCodeViewModel>>
    {
        private readonly ICustomerCodeService _CustomerCodeService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerCodeService CustomerCodeService, IMapper mapper)
        {
            _CustomerCodeService = CustomerCodeService;
            _mapper = mapper;
        }
        public async Task<Response<CustomerCodeViewModel>> Handle(GetCustomerCodeByIdQuery request, CancellationToken cancellationToken)
        {
            var getPlantCodeById = await _CustomerCodeService.GetCustomerCodeById(request.Id);
            return new Response<CustomerCodeViewModel>(getPlantCodeById);
        }
    }
}