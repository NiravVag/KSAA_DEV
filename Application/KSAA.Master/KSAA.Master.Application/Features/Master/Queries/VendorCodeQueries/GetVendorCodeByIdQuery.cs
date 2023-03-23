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

namespace KSAA.Master.Application.Features.Master.Queries.VendorCodeQueries
{
    public class GetVendorCodeByIdQuery : IRequest<Response<VendorCodeViewModel>>
    {
        public long Id { get; set; }
    }

    public class GetVendorCodeByIdQueryHandler : IRequestHandler<GetVendorCodeByIdQuery, Response<VendorCodeViewModel>>
    {
        private readonly IVendorCodeService _VendorCodeService;
        private readonly IMapper _mapper;

        public GetVendorCodeByIdQueryHandler(IVendorCodeService VendorCodeService, IMapper mapper)
        {
            _VendorCodeService = VendorCodeService;
            _mapper = mapper;
        }
        public async Task<Response<VendorCodeViewModel>> Handle(GetVendorCodeByIdQuery request, CancellationToken cancellationToken)
        {
            var getPlantCodeById = await _VendorCodeService.GetVendorCodeById(request.Id);
            return new Response<VendorCodeViewModel>(getPlantCodeById);
        }
    }
}